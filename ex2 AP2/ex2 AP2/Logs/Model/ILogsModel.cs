using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageService.ImageService.Logging;
namespace ex2_AP2.Logs.Model
{
    public interface ILogsModel
    {
        ObservableCollection<LogMessage> Logs { get; set; }
    }
}
