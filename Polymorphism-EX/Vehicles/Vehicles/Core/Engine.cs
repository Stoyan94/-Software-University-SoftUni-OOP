using System;
using System.Collections.Generic;
using Vehicles.Core.Interfaces;
using Vehicles.Factories.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IVehicleFactory vehicleFactory;

        private ICollection<IVehicel> vehicles;
        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
            vehicles = new List<IVehicel>();
        }

        public void Run()
        {          
            vehicles.Add(CreatVehicle());
            vehicles.Add(CreatVehicle());

            int commandsCount = int.Parse(reader.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                ProcessCommand();
            }

        }


        private IVehicel CreatVehicle()
        {
            string[] tokesn = reader.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IVehicel vehicle = vehicleFactory.Create(tokesn[0], double.Parse(tokesn[1]), double.Parse(tokesn[2]));

            return vehicle;
        }
        private void ProcessCommand()
        {
            string[] commandTokes = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }

}
