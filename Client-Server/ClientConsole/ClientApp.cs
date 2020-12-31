using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ClientConsole
{
    class ClientApp
    {
        private const string hostIp = "127.0.0.1";
        private const int port = 4321;
        static TcpClient client;
        static NetworkStream stream;


        static void Main(string[] args)
        {
            client = new TcpClient();
            try
            {
                client.Connect(hostIp, port);
                stream = client.GetStream();

                Thread receivedThread = new Thread(new ThreadStart(ReceiveMessage));
                receivedThread.Start();
                SendMessage();
            }
            catch
            {
                Console.WriteLine("closed");
            }
            finally
            {
                Disconnect();
            }
        }
        
        static void SendMessage()
        {
            Console.WriteLine("Enter your message: ");

            while (true)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }


        static void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();
                    Console.WriteLine(message);
                }
                catch
                {
                    Console.WriteLine("Подключение прервано!");
                    Console.ReadLine();
                    Disconnect();
                }
            }
        }

        static void Disconnect()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
            Environment.Exit(0);
        }
    }
}
