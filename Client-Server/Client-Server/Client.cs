using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client_Server
{
    public class Client
    {
        /// <summary>
        /// Client id
        /// </summary>
        protected internal string Id { get; private set; }

        /// <summary>
        /// Client stream
        /// </summary>
        protected internal NetworkStream Stream { get; set; }

        /// <summary>
        /// Client
        /// </summary>
        TcpClient client;

        /// <summary>
        /// Server
        /// </summary>
        Server server;

        /// <summary>
        /// String process delegate
        /// </summary>
        /// <param name="mes">Message</param>
        /// <param name="id">User id</param>
        private delegate void StringProcessDel(string mes, string id);

        /// <summary>
        /// String process event
        /// </summary>
        private event StringProcessDel StringProcess;

        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="client">Client</param>
        /// <param name="server">Server</param>
        public Client(TcpClient client, Server server)
        {
            StringProcess += Translit.TranslitString;
            Id = Guid.NewGuid().ToString();
            this.client = client;
            this.server = server;
            server.AddConnection(this);
        }

        /// <summary>
        /// Process method
        /// </summary>
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

        /// <summary>
        /// Get message from client stream
        /// </summary>
        /// <returns>Message string</returns>
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

        /// <summary>
        /// Close client
        /// </summary>
        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
