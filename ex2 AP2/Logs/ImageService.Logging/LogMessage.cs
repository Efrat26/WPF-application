using Logs.ImageService.Logging.Modal;
using Newtonsoft.Json;
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
            //Newtonsoft.Json.Linq.JObject logMessageItm = new Newtonsoft.Json.Linq.JObject();
            LogMessage logMessageItm = new LogMessage(null, MessageTypeEnum.INFO);
            logMessageItm.Message = this.Message;
            logMessageItm.Type = this.type;

            //logMessageItm["message"] = this.message;
            // logMessageItm["type"] = 
            return JsonConvert.SerializeObject(logMessageItm);
            //return logMessageItm.ToString();
        }
        public static LogMessage FromJSON(string str)
        {
            LogMessage logMsg = new LogMessage("",MessageTypeEnum.INFO);
            if (str != null)
            {
                logMsg = JsonConvert.DeserializeObject<LogMessage>(str);
                /*
                   JObject json = JObject.Parse(str);
                logMsg.Message = (string)json["message"];
                string tmp = (string)json["type"];
                if (tmp.Equals(MessageTypeEnum.FAIL.ToString()))
                {
                    logMsg.type = MessageTypeEnum.FAIL;
                }
                else if (tmp.Equals(MessageTypeEnum.INFO.ToString()))
                {
                    logMsg.type = MessageTypeEnum.INFO;
                }
                else
                {
                    logMsg.type = MessageTypeEnum.WARNING;
                }
                */
            }
            else
            {
                logMsg.Message = "error in creating log message from json";
                logMsg.Type = logMsg.type = MessageTypeEnum.FAIL;
            }
            return logMsg;
        }
    }
}
