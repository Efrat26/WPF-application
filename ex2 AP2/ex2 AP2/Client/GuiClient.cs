using Logs.Server;
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
    public sealed class GuiClient : IClient
    {
        private bool connected;
        private IPEndPoint ep;
        private TcpClient client;
        private NetworkStream stream;
        private BinaryReader reader;
        private BinaryWriter writer;

        private static volatile GuiClient instance;
        private static object syncRoot = new Object();
        public static GuiClient Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new GuiClient();
                    }
                }

                return instance;
            }
        }
        public void connect(String IP, int port)
        {
           
            ep = new IPEndPoint(IPAddress.Parse(IP), port);
            client = new TcpClient();
            client.Connect(ep);
            stream = client.GetStream();
            reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
            Console.WriteLine("You are connected");
        }
        public bool isConnected()
        {
            if (client.Connected)
            {
                this.connected = true;
                return true;
            }
            this.connected = false;
            return false;
        }
        public bool IsConnected { get { return this.connected; } set { } }
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
            try
            {
                // Get result from server
                result = reader.ReadString();
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
                writer.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine("error in writing to client: " + e.ToString());
            }
            finally
            {
                //writer.Dispose();
                //writer.Close();
            }

        }
    }
}
