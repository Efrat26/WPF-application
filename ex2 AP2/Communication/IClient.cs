using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_AP2.Settings.Client
{
    public delegate void MessageRecieved(String message);
    public interface IClient
    {
        void connect(String ip, int port);
        void write(String command);
        String read();  // blocking call
        void disconnect();
        bool isConnected();
        bool IsConnected{ get; set; }
        void Listen();
        event MessageRecieved GotMessage;
    }
}
