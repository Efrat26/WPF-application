using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs.AppConfigObjects
{
    /// <summary>
    /// represents an app config item
    /// </summary>
    public class ImageServiceAppConfigItem
    {
      //all the fields of the app config item & thier properties
        private String outputFolder;
        public String OutputFolder { get { return this.outputFolder; } set { this.outputFolder = value; } }
        private String handlers;
        public String Handlers { get { return this.handlers; } set { this.handlers = value; } }
        private String sourceName;
        public String SourceName { get { return this.sourceName; } set { this.sourceName = value; } }
        private String logName;
        public String LogName { get { return this.logName; } set { this.logName = value; } }
        private int thumbnailSize;
        public int ThumbnailSize{ get { return this.thumbnailSize; } set { this.thumbnailSize = value; } }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageServiceAppConfigItem"/> class.
        /// </summary>
        /// <param name="output">The output folder path.</param>
        /// <param name="handlers">The handlers.</param>
        /// <param name="source">The source name.</param>
        /// <param name="log">The log name.</param>
        /// <param name="size">The thumbnail size.</param>
        public ImageServiceAppConfigItem(String output, String handlers, String source,
            String log, int size)
        {
            this.outputFolder = output;
            this.sourceName = source;
            this.logName = log;
            this.handlers = handlers;
            this.thumbnailSize = size;
        }
        /// <summary>
        /// converts to jason object.
        /// </summary>
        /// <returns></returns>
        public string ToJSON()
        { 
            JObject appConfigItem = new JObject();
            appConfigItem["output"] = this.outputFolder;
            appConfigItem["source"] = this.sourceName;
            appConfigItem["log"] = this.logName;
            appConfigItem["handlers"] = this.handlers;
            appConfigItem["size"] = this.thumbnailSize;
            return appConfigItem.ToString();
        }
        /// <summary>
        /// converts back from the json.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static ImageServiceAppConfigItem FromJSON(string str)
        {
            ImageServiceAppConfigItem appconf = new ImageServiceAppConfigItem(null,null,null,null,0);
            try
            {
                JObject appconfItem = JObject.Parse(str);
                appconf.outputFolder = (string)appconfItem["output"];
                appconf.sourceName = (string)appconfItem["source"];
                appconf.logName = (string)appconfItem["log"];
                appconf.handlers = (string)appconfItem["handlers"];
                appconf.thumbnailSize = (int)appconfItem["size"];
            } catch (Exception)
            {
                Console.WriteLine("could not parse app conf item");
                return null;
            }
            return appconf;
            
           // return JsonConvert.DeserializeObject<ImageServiceAppConfigItem>(str);
        }
    }
}
