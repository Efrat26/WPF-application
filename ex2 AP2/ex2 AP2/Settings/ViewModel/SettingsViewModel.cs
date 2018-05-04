using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_AP2
{
    class SettingsViewModel : ViewModel
    {
        private ISettingsModel model;
        public SettingsViewModel()
        {
            model = new SettingsModel();
           // model.PropertyChanged += this.NotifyPropertyChanged;

        }
        public String OutputDirectory
        {
            get
            {
                return model.OutputDirectory;
            }
            set
            {
               model.OutputDirectory = value;
                NotifyPropertyChanged("OutputDirectory");
            }
        }
        public String SourceName
        {
            get
            {
                return model.SourceName;
            }
            set
            {
                model.SourceName = value;
                NotifyPropertyChanged("SourceName");
            }
        }
        public String LogName
        {
            get
            {
                return model.LogName;
            }
            set
            {
              model.LogName = value;
              NotifyPropertyChanged("LogName");
            }
        }
        public int ThumbnailSize
        {
            get
            {
                return model.ThumbnailSize;
            }
            set
            {
                int temp;
                try
                {
                    temp = Convert.ToInt32(value);
                    model.ThumbnailSize = temp;
                    NotifyPropertyChanged("ThumbnailSize");
                }
                catch
                {
                    Console.WriteLine("Problem in conversion to integer!");
                }

                
            }
        }
    }
}
