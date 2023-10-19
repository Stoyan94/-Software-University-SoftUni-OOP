using System;
using System.Collections.Generic;
using System.Linq;
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
                try
                {
                    ProcessCommand();
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
                
            }

            foreach (var vehicel in vehicles)
            {
                Console.WriteLine(vehicel);
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

            string command = commandTokes[0];
            string vehicleType = commandTokes[1];

            IVehicel vehicle = vehicles.FirstOrDefault(x=> x.GetType().Name == vehicleType);

            if (vehicle is null)
            {
                throw new ArgumentException("Invalid vegicle type");
            }

            if (command == "Drive")
            {
                double distance = double.Parse(commandTokes[2]);
                writer.WriteLine(vehicle.Drive(distance));
            }
            else if (command == "Refuel")
            {
                double amount = double.Parse(commandTokes[2]);
                vehicle.Refuel(amount);
            }
        }
    }

}
