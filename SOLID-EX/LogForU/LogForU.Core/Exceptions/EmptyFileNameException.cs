using System;

namespace LogForU.Core.Exceptions
{
    public class EmptyFileNameException : Exception
    {
        private const string DefaultMessage = "Created time of message cannot be null or whitespace";
        public EmptyFileNameException() 
            : base(DefaultMessage)
        {
            
        }

        public EmptyFileNameException(string message) 
            : base(message) 
        {
            
        }
    }
}
