using ex2_AP2.Settings.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logs;
using Logs.AppConfigObjects;
using Infrastructure.Enums;
using Logs.Controller.Handlers;
using System.Collections.ObjectModel;
using System.Threading;

namespace ex2_AP2
{
    class SettingsModel : ISettingsModel, INotifyPropertyChanged
    {
        private static Mutex mut = new Mutex();
        #region members
        public event PropertyChangedEventHandler PropertyChanged;
        private IClient client;
        private String outputDirectoryPath;
        private String sourceName;
        private String logName;
        private int thumbnailSize;
        private Boolean connectionSuccessful;
        private String handlerToClose;
        ObservableCollection<String> handlers;
        private bool configSet;
        #endregion
        #region properties
        public string OutputDirectory
        {
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
        public string LogName
        {
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
        public int ThumbnailSize
        {
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
        public ObservableCollection<String> Handlers
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

        #endregion
        public SettingsModel()
        {
            this.configSet = false;
            this.handlers = new ObservableCollection<String>();
            connectionSuccessful = false;
            bool innerstop = false;
            client = GuiClient.Instance;
            Task task = new Task(() =>
            {
                while (!innerstop)
                {
                    if (client != null && client.IsConnected)
                    {
                        innerstop = true;
                        Console.WriteLine("in settings model client != null");
                    }
                }
                if (client.isConnected())
                {
                    client.GotMessage += this.GotMeesage;
                    connectionSuccessful = true;
                    //while (!configSet)
                    //{
                        String appConfigCommand = ((int)CommandEnum.GetConfigCommand).ToString();
                        client.write(appConfigCommand);
                        Task.Delay(1000);

                    //}
                }
            });task.Start();
        }
        public void NotifyPropertyChanged(String propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public void RemoveHandler(String path)
        {
            this.handlerToClose = path;
            // bool stop = false;
            //Task task = new Task(() =>
            //{
            HandlerToClose h = new HandlerToClose(path);
            String jobject = h.ToJSON();
            int message = (int)CommandEnum.CloseHandler;
            String newMessage = message.ToString() + jobject;
            client.write(newMessage);
            //this.Listen();
        }

        public void GotMeesage(string message)
        {
            Console.WriteLine("in settings view model, got: " + message);

            if (message.Equals(Infrastructure.Enums.ResultMessgeEnum.Success.ToString())
            || message.Contains(Infrastructure.Enums.ResultMessgeEnum.Success.ToString()))
            {
                if (this.handlerToClose != null)
                {
                    Console.WriteLine("in settings model, got: " + message + ". removing handler now");
                    //stop = true;
                    App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                    {
                        this.handlers.Remove(this.handlerToClose);
                    });
                    NotifyPropertyChanged("Handlers");
                }
            }
            else if (message.Equals(Infrastructure.Enums.ResultMessgeEnum.Fail.ToString()))
            {

            }
            else if (this.configSet == false && message != null)
            {
                ImageServiceAppConfigItem initialConfig = ImageServiceAppConfigItem.FromJSON(message);
                if (initialConfig != null && !this.configSet)
                {
                    mut.WaitOne();
                    this.configSet = true;

                    Console.WriteLine(initialConfig.OutputFolder);
                    this.OutputDirectory = initialConfig.OutputFolder;
                    Console.WriteLine(initialConfig.LogName);
                    this.LogName = initialConfig.LogName;
                    Console.WriteLine(initialConfig.SourceName);
                    this.SourceName = initialConfig.SourceName;
                    Console.WriteLine(initialConfig.ThumbnailSize);
                    this.ThumbnailSize = initialConfig.ThumbnailSize;
                    App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                    {
                        string[] folders = initialConfig.Handlers.Split(';');

                        foreach (String folder in folders)
                        {
                            this.handlers.Add(folder);
                        }
                    });
                    mut.ReleaseMutex();
                }
            }
            else
            {

            }
        }
    }
}

/*
    while (!stop)
    {

        //this.client.write(jobject);
         string result = client.read();
        Console.WriteLine(result);
        if (result.Equals(ResultMessgeEnum.Success.ToString()))
        {
            Console.WriteLine("in settings model, got: " + result + ". removing handler now");
            stop = true;
            App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
        {
            this.handlers.Remove(path);
        });
            NotifyPropertyChanged("Handlers");

        //stop = true;
        //  res= true;
        }
        else
        {
        Console.WriteLine("something went wrong in removing handler");
       // Task.Delay(1000);
        //return false;
        }
        //res= false;
    }
});
task.Start();
//task.Wait();
// taskRes = task.Result;
// Console.WriteLine("in settings model after returning result, result is: " + taskRes);
// return res;
/*
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
                */
