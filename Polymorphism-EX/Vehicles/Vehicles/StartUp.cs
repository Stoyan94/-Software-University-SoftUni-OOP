using Vehicles.Core;
using Vehicles.Core.Interfaces;
using Vehicles.IO;

IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());

engine.Run();