using ex2_AP2.Logs.Model;
using Logs.ImageService.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_AP2.Logs.ViewModel
{
    /// <summary>
    /// the log tab view model
    /// </summary>
    /// <seealso cref="ex2_AP2.ViewModelBaseClass" />
    public class LogsViewModel : ViewModelBaseClass
    {
        /// <summary>
        /// The model
        /// </summary>
        private ILogsModel model;
        /// <summary>
        /// Gets or sets the logs.
        /// </summary>
        /// <value>
        /// The logs.
        /// </value>
        public ObservableCollection<LogMessage> Logs { get { return this.model.Logs; } set { } }
        /// <summary>
        /// Initializes a new instance of the <see cref="LogsViewModel"/> class.
        /// </summary>
        public LogsViewModel()
        {
            this.model = new LogsModel();
        }
        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged(e.PropertyName);
        }
    }
}
