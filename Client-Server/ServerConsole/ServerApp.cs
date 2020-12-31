using System;
using System.Threading;
using Client_Server;

namespace ServerConsole
{
    class ServerApp
    {
        static Server server = new Server();
        static Thread listenThread;

        public static void Main()
        {
            server.HostStatus += ShowMess;
            try
            {
                server = new Server();
                listenThread = new Thread(new ThreadStart(server.Listen));
                listenThread.Start();
            }
            catch
            {
                server.Disconnect();
            }
        }

        static void ShowMess(string mes) => Console.WriteLine(mes);
    }
}
