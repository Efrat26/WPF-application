using Logs.ImageService.Logging.Modal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Logs.ImageService.Logging
{
    /// <summary>
    /// handles the log message object
    /// </summary>
    public class LogMessage
    {
        /// <summary>
        /// The message
        /// </summary>
        private String message;
        /// <summary>
        /// The type of the message
        /// </summary>
        private MessageTypeEnum type;
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public String Message
        {
            get { return this.message; }
            set { this.message = value; }
        }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
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
        /// <summary>
        /// Initializes a new instance of the <see cref="LogMessage"/> class.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <param name="t">The t.</param>
        public LogMessage(String m, MessageTypeEnum t)
        {
            this.message = m;
            this.type = t;
        }
        /// <summary>
        /// converts to jason format.
        /// </summary>
        /// <returns></returns>
        public String ToJSON()
        {
            
            JObject LogMessageSer = new JObject();
            LogMessageSer["message"] = Message;
            LogMessageSer["type"] = Type.ToString();
            return LogMessageSer.ToString();
        }
        /// <summary>
        /// converts back from jason.
        /// in case it didnt succeded - it returns a message with
        /// type waringing and a message that it couldn't convert the jason
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
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