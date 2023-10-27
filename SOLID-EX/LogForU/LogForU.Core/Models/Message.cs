using LogForU.Core.Enums;

namespace LogForU.Core.Models
{
    public class Message
    {
        //TODO add validations
        public Message(string createdTime, string text, ReportLevel reportLeve)
        {
            this.CreatedTime = createdTime;
            this.Text = text;
            this.ReportLeve = reportLeve;
        }

        public string CreatedTime { get; private set; }
        public string Text { get; private set; }
        public ReportLevel ReportLeve { get; private set; }
    }
}
