using Food_Shortage.IO.Interfaces;
using System;

namespace Food_Shortage.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()=> Console.ReadLine();
    }
}
