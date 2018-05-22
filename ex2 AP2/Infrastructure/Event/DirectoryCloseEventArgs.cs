using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs.Modal.Event
{
    /// <summary>
    /// the arguments for the close directory command
    /// </summary>
    public class DirectoryCloseEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the directory path.
        /// </summary>
        /// <value>
        /// The directory path.
        /// </value>
        public string DirectoryPath { get; set; }
        /// <summary>
        /// Gets or sets  the message that goes to the logger.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="dirPath">The direcory's path.</param>
        /// <param name="message">The message.</param>
        public DirectoryCloseEventArgs(string dirPath, string message)
        {
            // Setting the Directory Name
            DirectoryPath = dirPath;
            // Storing the String
            Message = message;                          
        }
        public string ToJSON()
        {
            JObject directoryObj = new JObject();
            directoryObj["Path"] = this.DirectoryPath;
            directoryObj["Message"] = this.Message;
            return directoryObj.ToString();
        }
        public DirectoryCloseEventArgs FromJSON(string str)
        {
            DirectoryCloseEventArgs directory = new DirectoryCloseEventArgs(null,null);

            JObject directoryObj = JObject.Parse(str);
            directory.DirectoryPath = (string)directoryObj["Path"];
            directory.Message = (string)directoryObj["Message"];
            return directory;
        }
    }
}
