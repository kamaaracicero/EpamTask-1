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
        /// <summary>
        /// Server ip
        /// </summary>
        private const string ip = "127.0.0.1";

        /// <summary>
        /// Server port
        /// </summary>
        private const int port = 4321;

        /// <summary>
        /// Message delegate
        /// </summary>
        /// <param name="mes">Message</param>
        public delegate void MessageDelegate(string mes);

        /// <summary>
        /// Host status event
        /// </summary>
        public event MessageDelegate HostStatus;

        /// <summary>
        /// Server
        /// </summary>
        static TcpListener server;

        /// <summary>
        /// List of clients
        /// </summary>
        List<Client> clients = new List<Client>();

        /// <summary>
        /// Standart empty constructor
        /// </summary>
        public Server()
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            server = new TcpListener(ipAddress, port);
        }

        /// <summary>
        /// Add client to list
        /// </summary>
        /// <param name="client"></param>
        protected internal void AddConnection(Client client) => clients.Add(client);

        /// <summary>
        /// Remove client from list
        /// </summary>
        /// <param name="id">Client id</param>
        protected internal void RemoveConnection(string id)
        {
            Client client = clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
            {
                clients.Remove(client);
            }
        }

        /// <summary>
        /// Server process
        /// </summary>
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

        /// <summary>
        /// Send message from one user to rest users
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="id">User id</param>
        protected internal void BroadcastMessage(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id != id)
                    clients[i].Stream.Write(data, 0, data.Length);
            }
        }

        /// <summary>
        /// Disconnect server
        /// </summary>
        public void Disconnect()
        {
            server.Stop();
            foreach (Client client in clients)
                client.Close();
            Environment.Exit(0);
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
