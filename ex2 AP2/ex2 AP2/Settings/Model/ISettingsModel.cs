using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_AP2
{
    interface ISettingsModel
    {
        event PropertyChangedEventHandler PropertyChanged;
        String OutputDirectory { get; set; }
        String SourceName { get; set; }
        String LogName { get; set; }
        ObservableCollection<String> Handlers { get; set; }
        //bool ConnectionSuccessful { get; set; }
        int ThumbnailSize { get; set; }
        void NotifyPropertyChanged(String propName);
        void RemoveHandler(String path);
        //void OnPropertyChanged(object sender, PropertyChangedEventArgs e);
    }
}
