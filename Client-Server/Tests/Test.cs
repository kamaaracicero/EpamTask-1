using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Xunit;
using Client_Server;
using System.Text;

namespace Tests
{
    public class Test
    {
        #region Failed attempt
        /*
        [Fact]
        public void Test_Connection()
        {
            Server server = new Server();
            server.Listen();

            string message = "hello";
            byte[] data;
            byte[] receivedData = new byte[64];
            StringBuilder builder = new StringBuilder();
            int i = 0;

            TcpClient client1 = new TcpClient();
            client1.Connect(IPAddress.Parse("127.0.0.1"), 4321);

            TcpClient client2 = new TcpClient();
            client2.Connect(IPAddress.Parse("127.0.0.1"), 4321);

            NetworkStream client1Stream = client1.GetStream();
            NetworkStream client2Stream = client2.GetStream();
            
            data = Encoding.Unicode.GetBytes(message);
            client1Stream.Write(data, 0, data.Length);

            do
            {
                int bytes = client2Stream.Read(receivedData, 0, receivedData.Length);
                builder.Append(Encoding.Unicode.GetString(receivedData, 0, bytes));
                i++;
            } while (client2Stream.DataAvailable);

            Assert.Equal("hello", builder.ToString());
        }*/
        #endregion
        [Fact]
        public void Test_Translit()
        {
            string string1 = "привет";
            string string2 = "андрей";
            string string3 = "как дела?";

            Translit.TranslitString(string1, "test");
            Translit.TranslitString(string2, "test");
            Translit.TranslitString(string3, "test");

            Assert.Equal("privet", Translit.Library[0].Message);
            Assert.Equal("andrei`", Translit.Library[1].Message);
            Assert.Equal("kak dela?", Translit.Library[2].Message);
        }
        
    }
}
