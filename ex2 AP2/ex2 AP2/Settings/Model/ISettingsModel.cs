using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_AP2
{
    /// <summary>
    /// interface for the settings tab model
    /// </summary>
    public interface ISettingsModel
    {
        /// <summary>
        /// Occurs when a property changed.
        /// </summary>
        event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Gets or sets the output directory.
        /// </summary>
        /// <value>
        /// The output directory.
        /// </value>
        String OutputDirectory { get; set; }
        /// <summary>
        /// Gets or sets the name of the source name.
        /// </summary>
        /// <value>
        /// The name of the source.
        /// </value>
        String SourceName { get; set; }
        /// <summary>
        /// Gets or sets the name of the log name.
        /// </summary>
        /// <value>
        /// The name of the log.
        /// </value>
        String LogName { get; set; }
        /// <summary>
        /// Gets or sets the handlers.
        /// </summary>
        /// <value>
        /// The handlers.
        /// </value>
        ObservableCollection<String> Handlers { get; set; }
        /// <summary>
        /// Gets or sets the size of the thumbnail size.
        /// </summary>
        /// <value>
        /// The size of the thumbnail.
        /// </value>
        int ThumbnailSize { get; set; }
        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        void NotifyPropertyChanged(String propName);
        /// <summary>
        /// Removes the handler.
        /// </summary>
        /// <param name="path">The path to handler to move.</param>
        void RemoveHandler(String path);
        /// <summary>
        /// detemines what to do when got a meesage.
        /// </summary>
        /// <param name="message">The message.</param>
        void GotMeesage(String message);
    }
}
