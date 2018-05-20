using ex2_AP2.Settings.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_AP2
{
    class MainWindowModel : INotifyPropertyChanged
    {
        private IClient client;
        private bool connected;
        public bool IsConnected
        {
            get
            {
                return this.connected;
            }
            set
            {
                this.connected = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsConnected"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindowModel()
        {
            this.IsConnected = false;
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
