using MilitaryElite.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string output) => Console.WriteLine(output);
    }
}
