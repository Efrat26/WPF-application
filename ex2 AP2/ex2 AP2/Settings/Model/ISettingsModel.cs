using System;
using System.Collections.Generic;
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
        int ThumbnailSize { get; set; }
        void NotifyPropertyChanged(String propName);
        //void OnPropertyChanged(object sender, PropertyChangedEventArgs e);
    }
}
