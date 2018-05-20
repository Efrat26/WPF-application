using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logs.ImageService.Logging;
namespace ex2_AP2.Logs.Model
{
    /// <summary>
    /// interface for a log tab model
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public interface ILogsModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Gets or sets the logs.
        /// </summary>
        /// <value>
        /// The logs.
        /// </value>
        ObservableCollection<LogMessage> Logs { get; set; }
        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        void NotifyPropertyChanged(String propName);
        /// <summary>
        /// determines what to do when got a meesage.
        /// </summary>
        /// <param name="message">The message.</param>
        void GotMeesage(String message);
    }
}
