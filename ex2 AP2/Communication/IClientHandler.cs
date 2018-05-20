using Logs.Controller;
using Logs.ImageService.Logging.Modal;
using Logs.Modal.Event;
using System;
using System.Net.Sockets;

namespace Logs.Server
{
    /// <summary>
    /// General interface for handling the client
    /// </summary>
    public interface IClientHandler
    {
        /// <summary>
        /// method to handle the client.
        /// </summary>
        /// <param name="c">The client.</param>
        void HandleClient(TcpClient c);
        /// <summary>
        /// Sets a controller to execute the commands.
        /// </summary>
        /// <param name="c">the controller</param>
        void SetController(IImageController c);
        /// <summary>
        /// method to handle when command recieved.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CommandRecievedEventArgs"/> instance containing the event data.</param>
        void OnCommandRecieved(object sender, CommandRecievedEventArgs e);
        /// <summary>
        /// Called when close directory.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DirectoryCloseEventArgs"/> instance containing the event data.</param>
        void OnCloseDirectory(object sender, DirectoryCloseEventArgs e);
        /// <summary>
        /// Called when a log message recieved.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MessageRecievedEventArgs"/> instance containing the event data.</param>
        void OnLogMessageRecieved(object sender, MessageRecievedEventArgs e);
        /// <summary>
        /// Occurs when command recieved.
        /// </summary>
        event EventHandler<CommandRecievedEventArgs> CommandRecieved;
        /// <summary>
        /// Occurs when got a close command.
        /// </summary>
        event EventHandler<DirectoryCloseEventArgs> CloseCommand;
    }
}
