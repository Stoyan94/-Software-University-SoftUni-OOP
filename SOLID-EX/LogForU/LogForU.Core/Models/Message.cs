using LogForU.Core.Enums;
using LogForU.Core.Exceptions;
using LogForU.Core.Utils;
using System;

namespace LogForU.Core.Models
{
    public class Message
    {
        private string createdTime;
        private string text;
        public Message(string createdTime, string text, ReportLevel reportLeve)
        {
            this.CreatedTime = createdTime;
            this.Text = text;
            this.ReportLeve = reportLeve;
        }

        public string CreatedTime 
        {
            get => createdTime;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyCreatedTimeException();
                }

                if (!DateTimeValidator.ValidateDateime(value))
                {
                    throw new InvalidDateTimeException();
                }

                createdTime = value;
            } 
        }
        public string Text 
        {
            get => text;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyMessageTextException();
                }
                text = value;
            } 
            
        }
        public ReportLevel ReportLeve { get; private set; }
    }
}
