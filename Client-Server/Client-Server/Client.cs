using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client_Server
{
    public class Client
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream { get; set; }
        TcpClient client;
        Server server;

        private delegate void StringProcessDel(string mes, string id);
        private event StringProcessDel StringProcess;

        public Client(TcpClient client, Server server)
        {
            StringProcess += Translit.TranslitString;
            Id = Guid.NewGuid().ToString();
            this.client = client;
            this.server = server;
            server.AddConnection(this);
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                string message;
                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        if (!String.IsNullOrEmpty(message))
                            StringProcess?.Invoke(message, Id);
                        server.BroadcastMessage(message, this.Id);
                    }
                    catch
                    {
                        break;
                    }
                    finally
                    { }
                }
            }
            catch (Exception ex)
            { }
            finally
            {
                server.RemoveConnection(this.Id);
                Close();
            }
        }

        private string GetMessage()
        {
            byte[] data = new byte[64];
            StringBuilder builder = new StringBuilder();
            int bytes;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);

            return builder.ToString();
        }

        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }
    }
}
