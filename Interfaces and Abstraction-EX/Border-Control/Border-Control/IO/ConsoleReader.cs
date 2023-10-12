using Border_Control.IO.Interfaces;
using System;

namespace Border_Control.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
