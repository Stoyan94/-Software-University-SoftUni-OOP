using Food_Shortage.IO.Interfaces;
using System;

namespace Food_Shortage.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line) => Console.WriteLine(line);
    }
}
