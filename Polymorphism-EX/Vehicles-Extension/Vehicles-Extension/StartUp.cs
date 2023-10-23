using Vehicles_Extension.Core.Interfaces;
using Vehicles_Extension.Factories.Interfaces;
using Vehicles_Extension.Factories;
using Vehicles_Extension.IO.Interfaces;
using Vehicles_Extension.IO;
using Vehicles_Extension.Core;


IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IVehicleFactory vehicleFactory = new VehicleFactory();

IEngine engine = new Engine(reader, writer, vehicleFactory);

engine.Run();
