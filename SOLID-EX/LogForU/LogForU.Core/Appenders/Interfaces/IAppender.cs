using LogForU.Core.Models;

namespace LogForU.Core.Appenders.Interfaces
{
    public interface IAppender
    {
        void AppendMessage(Message message);
    }
}
