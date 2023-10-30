using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.Loggers.Interfaces;
using LogForU.Core.Models;
using System.Collections;
using System.Collections.Generic;

namespace LogForU.Core.Loggers
{    
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }
        public void Info(string dateTime, string message)
            => AppendAll(dateTime, message, ReportLevel.Info);
        

        public void Warning(string dateTime, string message) 
            => AppendAll(dateTime, message, ReportLevel.Warning);

        public void Error(string dateTime, string message) 
            => AppendAll(dateTime, message, ReportLevel.Error);

        public void Critical(string dateTime, string message) 
            => AppendAll(dateTime, message, ReportLevel.Critical);

        public void Fatal(string dateTime, string message) 
            => AppendAll(dateTime, message, ReportLevel.Fatal);

        private void AppendAll(string dateTime, string text, ReportLevel report)
        {
            Message message =  new(dateTime, text, report);

            foreach (var appender in appenders)
            {
                if (message.ReportLeve >= appender.ReportLevel)
                {                   
                    appender.AppendMessage(message);
                }
            }
        }

    }
}
