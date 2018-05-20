using ex2_AP2.Settings.Client;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ex2_AP2
{
    class MainWindowViewModel : ViewModelBaseClass
    {
        private IClient client;
        private bool connected;
        public bool IsConnected {get{return this.connected;} set{ this.connected = value; } }
        private DelegateCommand closingCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (closingCommand == null)
                {
                    closingCommand = new DelegateCommand(this.OnClose);
                    NotifyPropertyChanged("CloseCommand");
                }
                return closingCommand;
            }
            private set { }
        }
        public MainWindowViewModel()
        {
            closingCommand = new DelegateCommand(this.OnClose);
            // this.CloseCommand = new DelegateCommand(this.OnClose);
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
       
        private void OnClose()
        {
            Console.WriteLine("in on close of main window");
        }

    }
}
