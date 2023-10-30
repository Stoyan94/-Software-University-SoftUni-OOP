using LogForU.Core.Appenders;
using LogForU.Core.Enums;
using LogForU.Core.Layouts;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Loggers;
using LogForU.Core.Loggers.Interfaces;
using LogForU.Core.Utils;

ILayout layout = new SimpleLayout();

var consoleAppender = new ConsoleAppender(layout);

consoleAppender.ReportLevel = ReportLevel.Error;

DateTimeValidator.AddFormat("MM-dd-yyyy h:mm:ss tt");

var logger = new Logger(consoleAppender);

logger.Info("03-31-2015 5:33:07 PM", "Everything seems fine");
logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");

