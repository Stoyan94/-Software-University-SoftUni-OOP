using BirthdayCelebrations.Core;
using BirthdayCelebrations.Core.Interface;
using BirthdayCelebrations.IO;


IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());

engine.Run();
