using Logs.ImageService.Logging;
using Logs.ImageService.Logging.Modal;
using Logs.Modal.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs.Server
{
    //the server that links between the service (and the log) and the handlers of the directories
    public interface IServer
    {
        /// <summary>
        /// Raises when the service is about to close.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DirectoryCloseEventArgs"/> instance containing the event data.</param>
        void OnClose(object sender, DirectoryCloseEventArgs e);
        /// <summary>
        /// Occurs when command recieved.
        /// </summary>
        event EventHandler<CommandRecievedEventArgs> CommandRecieved;
        /// <summary>
        /// Called when got message.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MessageRecievedEventArgs"/> instance containing the event data.</param>
        void OnMessage(object sender, MessageRecievedEventArgs e);
        /// <summary>
        /// Occurs when log message recieved.
        /// </summary>
        event EventHandler<MessageRecievedEventArgs> LogMessageRecieved;
        /// <summary>
        /// Gets or sets the ip address.
        /// </summary>
        /// <value>
        /// The ip.
        /// </value>
        String IP { get; set; }
        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        int Port { get; set; }
        /// <summary>
        /// Sets the logger service.
        /// </summary>
        /// <param name="l">The logger service instance.</param>
        void SetLoggerService(ILoggingService l);
        /// <summary>
        /// Gets or sets the log.
        /// </summary>
        /// <value>
        /// The log.
        /// </value>
        ILoggingService Log { get; set; }
    }
}
