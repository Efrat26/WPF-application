using ex2_AP2.Settings.Client;
using Logs.Commands;
using Logs.ImageService.Logging;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
namespace ex2_AP2.Logs.Model
{
    /// <summary>
    ///  a log model - handles the logic for the log tab
    /// </summary>
    /// <seealso cref="ex2_AP2.Logs.Model.ILogsModel" />
    public class LogsModel : ILogsModel
    {
        #region members        
        /// <summary>
        /// The logs
        /// </summary>
        private ObservableCollection<LogMessage> logs;
        /// <summary>
        /// The client
        /// </summary>
        private IClient client;
        /// <summary>
        /// determines if the  connection successful
        /// </summary>
        private Boolean connectionSuccessful;
        #endregion members
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<LogMessage> Logs { get { return this.logs; } set { } }
        /// <summary>
        /// Initializes a new instance of the <see cref="LogsModel"/> class.
        /// </summary>
        public LogsModel()
        {
            this.logs = new ObservableCollection<LogMessage>();
            connectionSuccessful = false;
            client = GuiClient.Instance;
            bool innerstop = false;
            ///loop until the client is connected
            Task task = new Task(() =>
            {
                while (!innerstop)
                {
                    if (client != null && client.IsConnected)
                    {
                        innerstop = true;
                        Console.WriteLine("in logs model client != null");
                    }
                }
                //if client is connected - register to the event of got a message
                if (client.isConnected())
                {
                    connectionSuccessful = true;
                    this.client.GotMessage += this.GotMeesage;
                }
            }); task.Start();

        }
        /// <summary>
        /// determines what to do when got a meesage.
        /// </summary>
        /// <param name="message">The message.</param>
        public void GotMeesage(string message)
        {
            Console.WriteLine("in logs view model, got: " + message);

            if (message.Equals(Infrastructure.Enums.ResultMessgeEnum.Success.ToString()) ||
            message.Equals(Infrastructure.Enums.ResultMessgeEnum.Fail.ToString()))
            {
                Console.WriteLine("in logs model, got: " + message);
            }
            else
            {
                LogMessage log = LogMessage.FromJSON(message);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    this.logs.Add(log);
                    //NotifyPropertyChanged("logs");
                });
            }
        }
        /// <summary>
        /// Adds the log.
        /// </summary>
        /// <param name="logAsString">The log as string.</param>
        private void AddLog(String logAsString)
        {

        }
        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        public void NotifyPropertyChanged(string propName)
        {

        }

    }
}
