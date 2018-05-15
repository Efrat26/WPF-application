using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_AP2.Settings.Client
{
    interface IClient
    {
        void connect(String ip, int port);
        void write(String command);
        String read();  // blocking call
        void disconnect();
        bool isConnected();
    }
}
