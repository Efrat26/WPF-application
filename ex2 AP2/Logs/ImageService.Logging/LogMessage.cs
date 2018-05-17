﻿using Logs.ImageService.Logging.Modal;
using Newtonsoft.Json.Linq;
using System;

namespace Logs.ImageService.Logging
{
    public class LogMessage
    {
        private String message;
        private MessageTypeEnum type;
        public String Message
        {
            get { return this.message; }
            set { this.message = value; }
        }
        public MessageTypeEnum Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public LogMessage(String m, MessageTypeEnum t)
        {
            this.message = m;
            this.type = t;
        }
        public String ToJSON()
        {
            Newtonsoft.Json.Linq.JObject logMessageItm = new Newtonsoft.Json.Linq.JObject();
            logMessageItm["message"] = this.message;
            logMessageItm["type"] = this.type.ToString();
            return logMessageItm.ToString();
        }
        public static LogMessage FromJSON(string str)
        {
            LogMessage logMsg = new LogMessage("",MessageTypeEnum.INFO);
            JObject json = JObject.Parse(str);
            logMsg.Message = (string)json["message"];
            string tmp = (string)json["type"];
            if (tmp.Equals(MessageTypeEnum.FAIL.ToString()))
            {
                logMsg.type = MessageTypeEnum.FAIL;
            } else if (tmp.Equals(MessageTypeEnum.INFO.ToString()))
            {
                logMsg.type = MessageTypeEnum.INFO;
            }
            else
            {
                logMsg.type = MessageTypeEnum.WARNING;
            }
            return logMsg;
        }
    }
}
