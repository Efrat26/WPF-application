using ex2_AP2.Settings.Client;
using ImageService.Commands;
using ImageService.ImageService.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
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
            connectionSuccessful = false;
            client = new GuiClient();
            
            client.connect("127.0.0.1", 8000);
            if (client.isConnected())
            {
                connectionSuccessful = true;
                client.write(((int)Command_Enum.CommandEnum.LogCommand).ToString());
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
