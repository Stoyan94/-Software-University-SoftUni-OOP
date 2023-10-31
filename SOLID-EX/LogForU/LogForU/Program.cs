using LogForU.Core.Appenders;
using LogForU.Core.Enums;
using LogForU.Core.IO;
using LogForU.Core.Layouts;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Loggers;
using LogForU.Core.Loggers.Interfaces;
using LogForU.Core.Utils;

var simpleLayout = new SimpleLayout();
var consoleAppender = new ConsoleAppender(simpleLayout);

var file = new LogFile();
var fileAppender = new FileAppender(simpleLayout, file);

var logger = new Logger(consoleAppender, fileAppender);
logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");


