using System;
using Wild_Farm.IO.Interfaces;

namespace Wild_Farm.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
