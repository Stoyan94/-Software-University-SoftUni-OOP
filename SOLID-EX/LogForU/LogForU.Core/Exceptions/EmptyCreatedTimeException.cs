using System;

namespace LogForU.Core.Exceptions
{
    public class EmptyCreatedTimeException : Exception
    {
        private const string DefaultMessage = "File name cannot be null or whitespace";
        public EmptyCreatedTimeException() 
            : base(DefaultMessage)
        {
            
        }

        public EmptyCreatedTimeException(string message) 
            : base(message) 
        {
            
        }
    }
}
