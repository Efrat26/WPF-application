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
    class MainWindowViewModel : ViewModelBaseClass
    {
        private IClient client;
        private bool connected;
        public bool IsConnected {get{return this.model.IsConnected;}  }
        private MainWindowModel model;
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
