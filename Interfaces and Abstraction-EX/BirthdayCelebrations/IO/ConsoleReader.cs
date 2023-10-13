using BirthdayCelebrations.IO.Interfaces;
using System;

namespace BirthdayCelebrations.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
