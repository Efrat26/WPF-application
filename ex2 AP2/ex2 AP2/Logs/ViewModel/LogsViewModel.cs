using ex2_AP2.Logs.Model;
using Logs.ImageService.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_AP2.Logs.ViewModel
{
    public class LogsViewModel : ViewModelBaseClass
    {
        private ILogsModel model;
        public ObservableCollection<LogMessage> Logs { get { return this.model.Logs; } set { } }
        public LogsViewModel()
        {
            this.model = new LogsModel();
        }
        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged(e.PropertyName);
        }
    }
}
