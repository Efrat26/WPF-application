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
    /// <summary>
    /// the settings model instance
    /// </summary>
    /// <seealso cref="ex2_AP2.ISettingsModel" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    class SettingsModel : ISettingsModel, INotifyPropertyChanged
    {
        #region members        
        /// <summary>
        /// a mutex to lock the writer
        /// </summary>
        private static Mutex mut = new Mutex();
        /// <summary>
        /// The client
        /// </summary>
        private IClient client;
        /// <summary>
        /// The output directory path
        /// </summary>
        private String outputDirectoryPath;
        /// <summary>
        /// The source name
        /// </summary>
        private String sourceName;
        /// <summary>
        /// The log name
        /// </summary>
        private String logName;
        /// <summary>
        /// The thumbnail size
        /// </summary>
        private int thumbnailSize;
        /// <summary>
        /// determones if the connection done successful
        /// </summary>
        private Boolean connectionSuccessful;
        /// <summary>
        /// The handler to close
        /// </summary>
        private String handlerToClose;
        /// <summary>
        /// The handlers
        /// </summary>
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
        /// <summary>
        /// Occurs when a property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsModel"/> class.
        /// </summary>
        public SettingsModel()
        {
            this.configSet = false;
            this.handlers = new ObservableCollection<String>();
            connectionSuccessful = false;
            bool innerstop = false;
            client = GuiClient.Instance;
            Task task = new Task(() =>
            {
                //loop until teh client is connected
                while (!innerstop)
                {
                    if (client != null && client.IsConnected)
                    {
                        innerstop = true;
                        Console.WriteLine("in settings model client != null");
                    }
                }
                //register the method that handles what to do when got new message
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
        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        public void NotifyPropertyChanged(String propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        /// <summary>
        /// Removes the handler.
        /// </summary>
        /// <param name="path">The path to handler to move.</param>
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
        /// <summary>
        /// detemines what to do when got a meesage (either got feedback for the operation or got the 
        /// primary settings of the app config).
        /// </summary>
        /// <param name="message">The message.</param>
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
                try
                {
                    Console.WriteLine("in settings model - got remove handler command, " +
                        "command is: " + message);
                    HandlerToClose h = HandlerToClose.FromJSON(message);
                    if (handlers.Contains(h.Path))
                    {
                        App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                        {
                            this.handlers.Remove(h.Path);
                        });
                        //NotifyPropertyChanged("Handlers");
                    }

                }
                catch (Exception)
                {

                }
            }
        }
    }
}
