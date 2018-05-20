using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs.Controller.Handlers
{
    /// <summary>
    /// class that handles the handler to close
    /// </summary>
    public class HandlerToClose
    {
        /// <summary>
        /// The path of the handler
        /// </summary>
        private string path;
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path { get { return this.path; } set { this.path = value; } }
        /// <summary>
        /// Initializes a new instance of the <see cref="HandlerToClose"/> class.
        /// </summary>
        /// <param name="p">The path.</param>
        public HandlerToClose(String p)
        {
            this.path = p;
        }
        /// <summary>
        /// converts to the json.
        /// </summary>
        /// <returns></returns>
        public string ToJSON()
        {
            JObject jitem = new JObject();
            jitem["path"] = this.path;
            return jitem.ToString();
        }
        /// <summary>
        /// converts back from json.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static HandlerToClose FromJSON(string str)
        {
            HandlerToClose handlerObj = new HandlerToClose(null);
            JObject handlerObjItem = JObject.Parse(str);
            handlerObj.path = (string)handlerObjItem["path"];
            return handlerObj;
        }
    }
}
