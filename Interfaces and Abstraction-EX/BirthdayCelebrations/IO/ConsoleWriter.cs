using BirthdayCelebrations.IO.Interfaces;
using System;

namespace BirthdayCelebrations.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line) => Console.WriteLine(line);
    }
}
