using ex2_AP2.Settings.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageService;
using ImageService.AppConfigObjects;

namespace ex2_AP2
{
    class SettingsModel : ISettingsModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IClient client;
        private String outputDirectoryPath;
        private String sourceName;
        private String logName;
        private int thumbnailSize;
        public SettingsModel()
        {
            client = new SettingsClient();
            client.connect("127.0.0.1", 8000);
            String appConfigCommand = ((int)ImageService.ImageService.Infrastructure.Enums.CommandEnum.GetConfigCommand).ToString();
            if (client != null)
            {
                client.write(appConfigCommand);
                String answer = client.read();
            }
            String result;
            /*
            Task<String> taskA = new Task<String>(() => {
                while (client.read() == null) {
                    Task.Delay(1000);
                }
                result = client.read();
                return result;
            });
            // Start the task.
            taskA.Start();
            taskA.Wait();
            String taskResult = taskA.Result;
        */    
        }

        public string OutputDirectory {
            get
            {
                return this.outputDirectoryPath;
            }
            set
            {
                outputDirectoryPath = value;
                NotifyPropertyChanged("OutputDirectory");

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
                NotifyPropertyChanged("SourceName");
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
                NotifyPropertyChanged("LogName");
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
                NotifyPropertyChanged("ThumbnailSize");
            }
        }
        public void NotifyPropertyChanged(String propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
