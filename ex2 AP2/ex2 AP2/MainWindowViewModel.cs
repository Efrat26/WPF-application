using ex2_AP2.Settings.Client;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ex2_AP2
{
    /// <summary>
    /// the main window view model
    /// </summary>
    /// <seealso cref="ex2_AP2.ViewModelBaseClass" />
    class MainWindowViewModel : ViewModelBaseClass
    {
        /// <summary>
        /// The client
        /// </summary>
        private IClient client;
        /// <summary>
        /// true if is connected
        /// </summary>
        private bool connected;
        /// <summary>
        /// Gets a value indicating whether this client is connected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </value>
        public bool IsConnected {get{return this.model.IsConnected;}  }
        /// <summary>
        /// The model
        /// </summary>
        private MainWindowModel model;
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// creates the model and register to the event
        /// </summary>
        public MainWindowViewModel()
        {
            this.model = new MainWindowModel();
            this.model.PropertyChanged += this.OnPropertyChanged;
           
            
        }
       public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.NotifyPropertyChanged(e.PropertyName);
        }
        private void OnClose()
        {
            Console.WriteLine("in on close of main window");
        }

    }
}
