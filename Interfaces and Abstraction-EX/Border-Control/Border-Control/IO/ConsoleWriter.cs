using Border_Control.IO.Interfaces;
using System;

namespace Border_Control.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line) => Console.WriteLine(line);
    }
}
