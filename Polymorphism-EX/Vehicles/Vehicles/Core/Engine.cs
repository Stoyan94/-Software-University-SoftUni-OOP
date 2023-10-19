using System;
using Vehicles.Core.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] tokesn = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            
        }
    }

}
