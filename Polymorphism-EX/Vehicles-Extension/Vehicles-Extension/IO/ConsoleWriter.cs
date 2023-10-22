using System;
using Vehicles_Extension.IO.Interfaces;

namespace Vehicles_Extension.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line) => Console.WriteLine(line);
    }
}
