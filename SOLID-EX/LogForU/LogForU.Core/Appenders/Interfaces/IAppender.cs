using LogForU.Core.Enums;
using LogForU.Core.Models;

namespace LogForU.Core.Appenders.Interfaces
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        int MessagesAppended { get;}
        void AppendMessage(Message message);
    }
}
