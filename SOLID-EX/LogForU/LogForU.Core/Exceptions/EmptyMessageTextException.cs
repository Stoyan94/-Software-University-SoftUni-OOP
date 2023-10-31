﻿using System;

namespace LogForU.Core.Exceptions
{
    public class EmptyMessageTextException : Exception
    {
        private const string DefaultMessage = "Massage text cannot be null or whitespace";
        public EmptyMessageTextException() 
            : base(DefaultMessage)
        {
            
        }

        public EmptyMessageTextException(string message) 
            : base(message) 
        {
            
        }
    }
}