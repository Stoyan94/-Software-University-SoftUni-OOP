using System;
using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.Models;

namespace LogForU.Core.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ReportLevel reportLevel = ReportLevel.Info)
        {
            ReportLevel = reportLevel;
        }
        public ReportLevel ReportLevel { get;  set; }

        public int MessagesAppended { get; private set; }

        public void AppendMessage(Message message)
        {
            Console.WriteLine(message.CreatedTime);
            Console.WriteLine(message.Text);
            Console.WriteLine(message.ReportLeve);

            MessagesAppended++;
        }
    }
}
