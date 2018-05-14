﻿using ex2_AP2.Settings.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageService;
using ImageService.AppConfigObjects;
using ImageService.ImageService.Infrastructure.Enums;
using ImageService.Controller.Handlers;

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
        private Boolean connectionSuccessful;
        List<String> handlers;
        public SettingsModel()
        {
            this.handlers = new List<String>();
            connectionSuccessful = false;
            client = new SettingsClient();
            client.connect("127.0.0.1", 8000);
            if (client.isConnected())
            {
                connectionSuccessful = true;
            }
            String appConfigCommand = ((int)CommandEnum.GetConfigCommand).ToString();
            //set the inital configurations
            String answer = null;
            if (client != null)
            {
                client.write(appConfigCommand);
                 answer = client.read();
            }
            if (!answer.Equals(ResultMessgeEnum.Fail))
            {
                ImageServiceAppConfigItem initialConfig = ImageServiceAppConfigItem.FromJSON(answer);
                this.OutputDirectory = initialConfig.OutputFolder;
                this.LogName = initialConfig.LogName;
                this.sourceName = initialConfig.SourceName;
                this.thumbnailSize = initialConfig.ThumbnailSize;
                string[] folders = initialConfig.Handlers.Split(';');
                foreach (String folder in folders)
                {
                    this.handlers.Add(folder);
                }
            }
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
        public List<String> Handlers
        {
            get
            {
                return this.handlers;
            }
            set
            {
                handlers = value;
                NotifyPropertyChanged("Handlers");
            }
        }
        public void NotifyPropertyChanged(String propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public bool RemoveHandler(String path)
        {
            HandlerToClose h = new HandlerToClose(path);
            String jobject = h.ToJSON();
            int message = (int)CommandEnum.CloseHandler;
            client.write(message.ToString());
            this.client.write(jobject);
            string result = client.read();
            if (result.Equals(ResultMessgeEnum.Success.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
