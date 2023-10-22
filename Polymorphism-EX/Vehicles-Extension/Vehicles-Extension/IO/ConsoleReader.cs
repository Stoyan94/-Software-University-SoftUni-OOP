using System;
using Vehicles_Extension.IO.Interfaces;

namespace Vehicles_Extension.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
