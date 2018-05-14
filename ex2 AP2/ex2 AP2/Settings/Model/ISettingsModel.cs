﻿using System;
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
        List<String> Handlers { get; set; }
        //bool ConnectionSuccessful { get; set; }
        int ThumbnailSize { get; set; }
        void NotifyPropertyChanged(String propName);
        bool RemoveHandler(String path);
        //void OnPropertyChanged(object sender, PropertyChangedEventArgs e);
    }
}
