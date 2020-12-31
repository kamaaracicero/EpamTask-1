using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client_Server
{
    public class Server
    {
        private const string ip = "127.0.0.1";
        private const int port = 4321;

        public delegate void MessageHandler(string mes);
        public event MessageHandler HostStatus;

        static TcpListener server;

        List<Client> clients = new List<Client>();

        public Server()
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            server = new TcpListener(ipAddress, port);
        }

        protected internal void AddConnection(Client client) => clients.Add(client);

        protected internal void RemoveConnection(string id)
        {
            Client client = clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
            {
                clients.Remove(client);
            }
        }

        public void Listen()
        {
            try
            {
                server.Start();
                HostStatus?.Invoke("Host start");
                while (true)
                {
                    TcpClient tcpClient = server.AcceptTcpClient();

                    Client client = new Client(tcpClient, this);
                    Thread clienThread = new Thread(new ThreadStart(client.Process));
                    clienThread.Start();
                }
            }
            catch (Exception ex)
            {
                HostStatus?.Invoke(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        protected internal void BroadcastMessage(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id != id)
                    clients[i].Stream.Write(data, 0, data.Length);
            }
        }

        public void Disconnect()
        {
            server.Stop();
            foreach (Client client in clients)
                client.Close();
            Environment.Exit(0);
        }
    }
}
