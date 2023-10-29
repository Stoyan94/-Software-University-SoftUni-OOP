﻿using LogForU.Core.Appenders;
using LogForU.Core.Enums;
using LogForU.Core.Loggers;
using LogForU.Core.Loggers.Interfaces;

var consoleAppender = new ConsoleAppender();
consoleAppender.ReportLevel = ReportLevel.Error;

var logger = new Logger(consoleAppender);

logger.Info("  ", "Everything seems fine");
logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");