
using MilitaryElite.Core;
using MilitaryElite.Core.Interfaces;
using MilitaryElite.IO;

IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());

engine.Run();