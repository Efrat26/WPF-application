using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_AP2.Settings.Client
{
    /// <summary>
    /// delegate for functions that handle the messages
    /// </summary>
    /// <param name="message">The message.</param>
    public delegate void MessageRecieved(String message);
    /// <summary>
    /// client interface - contains functions such as read, write, connect to server
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Connects the specified ip & port.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        void connect(String ip, int port);
        /// <summary>
        /// Writes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        void write(String command);
        /// <summary>
        /// Reads data.
        /// </summary>
        /// <returns>the data read</returns>
        String read();  // blocking call        
        /// <summary>
        /// Disconnects client.
        /// </summary>
        void disconnect();
        /// <summary>
        /// Determines whether client is connected.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if client is connected; otherwise, <c>false</c>.
        /// </returns>
        bool isConnected();
        /// <summary>
        /// Gets or sets a value indicating whether this instance is connected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </value>
        bool IsConnected { get; set; }
        /// <summary>
        /// Listens to incoming messages.
        /// </summary>
        void Listen();
        /// <summary>
        /// Occurs when the client got message.
        /// </summary>
        event MessageRecieved GotMessage;
    }
}
