using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.IO.Interfaces;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Models;
using System;
using System.IO;

namespace LogForU.Core.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ILogFile logFile, ReportLevel report = ReportLevel.Info)
        {
            Layout = layout;
            LogFile = logFile;
            ReportLevel = report;
        }

        public ILayout Layout { get; private set; }

        public ILogFile LogFile { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get; private set; }

        public void AppendMessage(Message message)
        {
            string content = string.Format(Layout.Format, message.CreatedTime, message.ReportLevel, message.Text);

            File.AppendAllText(LogFile.FullPath, content + Environment.NewLine);

            MessagesAppended++;
        }
    }
}
