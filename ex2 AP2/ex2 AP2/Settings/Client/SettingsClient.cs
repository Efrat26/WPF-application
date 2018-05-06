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

        private IPEndPoint ep;
        private TcpClient client;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        public void connect(String IP, int port)
        {
            //ep = new IPEndPoint(IPAddress.Parse(IP), port);
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            client = new TcpClient();
            client.Connect(ep);
            stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            Console.WriteLine("You are connected");
        }

        public void disconnect()
        {
            writer.Close();
            reader.Close();
            stream.Close();
            client.Close();
        }

        public String read()
        {
            String result;
            // if (!client.Connected) { client.Connect(ep); }

            try
            {
                // Get result from server
                result = reader.ReadLine();
                return result;
            }
            catch (Exception)
            {

            }

            return null;
        }

        public void write(String command)
        {
            //if (!client.Connected) { client.Connect(ep); }
            try
            {
                // Send data to server
                writer.Write(command);
            }
            catch (Exception)
            {

            }
            finally
            {
                writer.Dispose();
                writer.Close();
            }

        }
    }
}
