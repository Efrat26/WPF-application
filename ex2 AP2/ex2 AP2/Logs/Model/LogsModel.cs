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
            
            client.connect("127.0.0.1", 8000);
            if (client.isConnected())
            {
                connectionSuccessful = true;
                String msg = ((int)Infrastructure.Enums.CommandEnum.LogCommand).ToString();
                Console.WriteLine("in logs modedl, sending: " + msg);
                client.write(msg);
                this.Listen();
            }
            
        }
        public void Listen()
        {
            Boolean stop = false;
            Task task = new Task(() =>
            {
                while (!stop)
                {
                    string commandLine = client.read();
                    Console.WriteLine("in logs view model, got: "+commandLine);
                    if (commandLine.Equals(Infrastructure.Enums.ResultMessgeEnum.Success.ToString()) ||
                    commandLine.Equals(Infrastructure.Enums.ResultMessgeEnum.Fail.ToString()))
                    {
                        Console.WriteLine("in logs model, got: " + commandLine);
                    }
                    else
                    {
                        Console.WriteLine("in logs model going to parse to json, got: " + commandLine);
                        LogMessage log = LogMessage.FromJSON(commandLine);
                        App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                        {
                            this.logs.Add(log);
                            NotifyPropertyChanged("logs");
                        });
                    }
                }
            });
            task.Start();
        }
        private void AddLog(String logAsString)
        {

        }
        public void NotifyPropertyChanged(string propName)
        {
            
        }
    }
}
