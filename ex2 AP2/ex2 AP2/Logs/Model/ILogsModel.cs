using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logs.ImageService.Logging;
namespace ex2_AP2.Logs.Model
{
    public interface ILogsModel : INotifyPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<LogMessage> Logs { get; set; }
        void NotifyPropertyChanged(String propName);
    }
}
