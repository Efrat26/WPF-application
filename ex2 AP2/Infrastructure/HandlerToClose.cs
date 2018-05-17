﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs.Controller.Handlers
{
    public class HandlerToClose
    {
        private string path;
        public string Path { get { return this.path; } set { this.path = value; } }
        public HandlerToClose(String p)
        {
            this.path = p;
        }
        public string ToJSON()
        {
            JObject appConfigItem = new JObject();
            appConfigItem["path"] = this.path;
            return appConfigItem.ToString();
        }
        public static HandlerToClose FromJSON(string str)
        {
            HandlerToClose handlerObj = new HandlerToClose(null);
            JObject handlerObjItem = JObject.Parse(str);
            handlerObj.path = (string)handlerObjItem["path"];
            return handlerObj;
        }
    }
}
