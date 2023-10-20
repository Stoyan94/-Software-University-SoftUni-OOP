using Wild_Farm.Core;
using Wild_Farm.Core.Interfaces;
using Wild_Farm.IO;

IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());

engine.Run();