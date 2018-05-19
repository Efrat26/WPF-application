using ex2_AP2.Settings.Client;
using Logs.Commands;
using Logs.ImageService.Logging;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
namespace ex2_AP2.Logs.Model
{
    public class LogsModel : ILogsModel
    {
        private ObservableCollection<LogMessage> logs;
        public ObservableCollection<LogMessage> Logs { get {return this.logs; } set { } }
        private IClient client;
        private Boolean connectionSuccessful;
        public event PropertyChangedEventHandler PropertyChanged;
        public LogsModel()
        {
            this.logs = new ObservableCollection<LogMessage>();
            connectionSuccessful = false;
            client = GuiClient.Instance;
            bool innerstop = false;
            
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
                if (client.isConnected())
                {
                   // Task.Delay(4000);
                    connectionSuccessful = true;
                    this.client.GotMessage += this.GotMeesage;
                   // String msg = ((int)Infrastructure.Enums.CommandEnum.LogCommand).ToString();
                   // Console.WriteLine("in logs modedl, sending: " + msg);
                    //client.write(msg);
                    //this.Listen();
                }
            });task.Start();
            
        }
        private void AddLog(String logAsString)
        {

        }
        public void NotifyPropertyChanged(string propName)
        {
            
        }

        public string GotMeesage(string message)
        {
            Console.WriteLine("in logs view model, got: " + message);

            if (message.Equals(Infrastructure.Enums.ResultMessgeEnum.Success.ToString()) ||
            message.Equals(Infrastructure.Enums.ResultMessgeEnum.Fail.ToString()))
            {
                Console.WriteLine("in logs model, got: " + message);
            }
            else
            {
               // Console.WriteLine("in logs model going to parse to json, got: " + message);
               // message = message.Remove(message.Length - 1);
                //message = "{" + message;
               // Console.WriteLine("command line after corrections: " + message);
                LogMessage log = LogMessage.FromJSON(message);
                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {
                    this.logs.Add(log);
                    NotifyPropertyChanged("logs");
                });
            }
            return null;
        }
    }
}
