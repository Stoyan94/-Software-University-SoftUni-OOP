using System;
using Wild_Farm.IO.Interfaces;
using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(object obj)
          => Console.WriteLine(obj);
    }
}
