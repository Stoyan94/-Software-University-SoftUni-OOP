using Border_Control.Core;
using Border_Control.Core.Interface;
using Border_Control.IO;
using System;

IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());

engine.Run();
