using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ex2_AP2.Settings.Client
{
    class SettingsClient : IClient
    {

        IPEndPoint ep;
        TcpClient client;
        public void connect(String IP, int port)
        {
            ep = new IPEndPoint(IPAddress.Parse(IP), port);
            client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("You are connected");
        }

        public void disconnect()
        {
            client.Close();
        }

        public String read()
        {
            String result;
            using (NetworkStream stream = client.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            {

                // Get result from server
                result = reader.ReadString();

            }
            return result;
        }

        public void write(String command)
        {
            using (NetworkStream stream = client.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                // Send data to server
                writer.Write(command);
            }
        }
    }
}
