using ex2_AP2.Settings.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_AP2
{
    /// <summary>
    /// the main window model class
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    class MainWindowModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The client
        /// </summary>
        private IClient client;
        /// <summary>
        /// true if client is connected and false otherwise
        /// </summary>
        private bool connected;
        /// <summary>
        /// Gets or sets a value indicating whether this instance is connected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </value>
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
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowModel"/> class.
        /// connects to the client and starts the listening method
        /// </summary>
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
