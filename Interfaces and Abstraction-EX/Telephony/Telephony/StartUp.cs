using System;
using Telephony.Core;
using Telephony.Core.Interfaces;
using Telephony.IO;
using Telephony.Models;
using Telephony.Models.Interfaces;

IEngine engine = new Engine(new ConsoleReader(), new FileWriter());

engine.Run();