namespace MilitaryElite.IO
{
    using System;

    using Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void Write(string text) => Console.Write(text);
        

      
    }
}