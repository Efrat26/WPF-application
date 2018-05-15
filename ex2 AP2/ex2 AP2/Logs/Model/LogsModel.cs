using ImageService.ImageService.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_AP2.Logs.Model
{
    public class LogsModel : ILogsModel
    {
        private ObservableCollection<LogMessage> logs;
        public ObservableCollection<LogMessage> Logs { get {return this.logs; } set { } }
        public LogsModel()
        {

        }
    }
}
