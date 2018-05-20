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
            set
            {
                object tmp = value;
                if (tmp.Equals(MessageTypeEnum.FAIL.ToString()) || (int)tmp == 0)
                {
                    this.type = MessageTypeEnum.FAIL;
                }
                else if (tmp.Equals(MessageTypeEnum.INFO.ToString()) || (int)tmp == 1)
                {
                    this.type = MessageTypeEnum.INFO;
                }
                else if (tmp.Equals(MessageTypeEnum.WARNING.ToString()) || (int)tmp == 2)
                {
                    this.type = MessageTypeEnum.WARNING;
                }

                else
                {
                    this.type = MessageTypeEnum.WARNING;
                }
            }
        }
        public LogMessage(String m, MessageTypeEnum t)
        {
            this.message = m;
            this.type = t;
        }
        public String ToJSON()
        {
            
            JObject LogMessageSer = new JObject();
            LogMessageSer["message"] = Message;
            LogMessageSer["type"] = Type.ToString();
            return LogMessageSer.ToString();
        }
        public static LogMessage FromJSON(string str)
        {
            LogMessage logMsg = new LogMessage("",MessageTypeEnum.FAIL);
            if (str != null)
            {
                try
                {
                    JObject logObj = JObject.Parse(str);
                    logMsg.Message = (string)logObj["message"];
                    string tmp = (string)logObj["type"];
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
                } catch(Exception e)
                {
                    logMsg.Message = "error in creating log message from json";
                    logMsg.Type = logMsg.type = MessageTypeEnum.FAIL;
                }
               
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