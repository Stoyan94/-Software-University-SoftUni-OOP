using System;
using Wild_Farm.IO.Interfaces;

namespace Wild_Farm.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line) => Console.WriteLine(line);
    }
}
