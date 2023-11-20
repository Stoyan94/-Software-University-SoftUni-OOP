using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Core.Interfaces;
using Vehicles.Factories.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private readonly ICollection<IVehicle> vehicles;

        private Engine()
        {
            this.vehicles = new List<IVehicle>();
        }

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory) : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {
            vehicles.Add(CreatVehicle());
            vehicles.Add(CreatVehicle());

            int commandsCountInput = int.Parse(reader.ReadLine());

            for (int i = 0; i < commandsCountInput; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle);
            }
        }

        private void ProcessCommand()
        {
            string[] cmdArgs = reader.ReadLine().Split(" ",
                    StringSplitOptions.RemoveEmptyEntries);

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == cmdArgs[1]);

            if (cmdArgs[0] == "Drive")
            {
                writer.WriteLine(vehicle.Drive(double.Parse(cmdArgs[2])));
            }

            if (cmdArgs[0] == "Refuel")
            {
                vehicle.Refuel(double.Parse(cmdArgs[2]));
            }

            
        }

        private IVehicle CreatVehicle()
        {
            string[] input = reader.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            IVehicle vehicle = vehicleFactory.Create(input[0], double.Parse(input[1]), double.Parse(input[2]));

            return vehicle;
        }
    }
}
