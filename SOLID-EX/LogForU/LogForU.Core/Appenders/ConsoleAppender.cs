using System;
using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Models;

namespace LogForU.Core.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender( ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
        {
            Layout = layout;
            ReportLevel = reportLevel;
        }
        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get;  set; }

        public int MessagesAppended { get; private set; }


        public void AppendMessage(Message message)
        {
            string result = string.Format(Layout.Format, message.CreatedTime, message.ReportLevel, message.Text);

           Console.WriteLine(result);

            MessagesAppended++;
        }
    }
}
