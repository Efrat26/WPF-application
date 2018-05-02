using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_AP2
{
    class SettingsModel : ISettingsModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private String outputDirectoryPath;
        private String sourceName;
        private String logName;
        private int thumbnailSize;

        public string OutputDirectory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SourceName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LogName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ThumbnailSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
