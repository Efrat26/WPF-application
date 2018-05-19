using ex2_AP2.Settings.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_AP2
{
    class MainWindowViewModel : ViewModelBaseClass
    {
        private IClient client;
        private bool connected;
        public bool IsConnected {get{return this.connected;} set{ this.connected = value; } }
        public MainWindowViewModel()
        {
            this.connected = false;
           // client =new GuiClient();
            client = GuiClient.Instance;
            client.connect(Communication.CommunicationDetails.IP, Communication.CommunicationDetails.port);
            if (client.IsConnected)
            {
                this.connected = true;
                client.Listen();
            }
        }
    }
}
