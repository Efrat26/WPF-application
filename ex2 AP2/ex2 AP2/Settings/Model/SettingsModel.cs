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

        public string OutputDirectory {
            get
            {
                return this.outputDirectoryPath;
            }
            set
            {
                outputDirectoryPath = value;
            }
        }
        public string SourceName
        {
            get
            {
                return this.sourceName;
            }
            set
            {
                sourceName = value;
            }
        }
        public string LogName {
            get
            {
                return this.logName;
            }
            set
            {
                logName = value;
            }
        }
        public int ThumbnailSize {
            get
            {
                return this.thumbnailSize;
            }
            set
            {
                thumbnailSize = value;
            }
        }
    }
}
