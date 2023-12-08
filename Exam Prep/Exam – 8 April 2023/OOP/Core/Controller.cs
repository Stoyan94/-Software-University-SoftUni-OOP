using RobotService.Core.Contracts;
using RobotService.Models.Contracts;
using RobotService.Models.RobotModels;
using RobotService.Models.SupplementModels;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using System;
using System.Linq;
using System.Text;


namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IRepository<ISupplement> supplemets;
        private readonly IRepository<IRobot> robots;

        public Controller()
        {
            supplemets = new SupplementRepository();
            robots = new RobotRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            if (typeName == nameof(DomesticAssistant))
            {
                robots.AddNew(new DomesticAssistant(model));
            }
            else if (typeName == nameof(IndustrialAssistant))
            {
                robots.AddNew(new IndustrialAssistant(model));
            }
            else
            {
                return $"Robot type {typeName} cannot be created.";
            }

            return $"{typeName} {model} is created and added to the RobotRepository.";
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName == nameof(SpecializedArm))
            {
                supplemets.AddNew(new SpecializedArm());
            }
            else if (typeName == nameof(LaserRadar))
            {
                supplemets.AddNew(new LaserRadar());
            }
            else
            {
                return $"{typeName} is not compatible with our robots.";
            }

            return $"{typeName} is created and added to the SupplementRepository.";
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            var currSupplement = supplemets
                .Models()
                .FirstOrDefault(t => t.GetType().Name == supplementTypeName);

            var currRobot = robots
                .Models()
                .FirstOrDefault(m => m.Model == model && 
            !m.InterfaceStandards.Contains(currSupplement.InterfaceStandard));

            if (currRobot is null)
            {
                return $"All {model} are already upgraded!";
            }

            currRobot.InstallSupplement(currSupplement);
            supplemets.RemoveByName(supplementTypeName);

            return $"{model} is upgraded with {supplementTypeName}.";
        }
        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            var currRobots = robots
                .Models()
                .Where(i => i.InterfaceStandards.Contains(intefaceStandard))
                .OrderByDescending(b => b.BatteryLevel);

            if (!currRobots.Any())
            {
                return $"Unable to perform service, {intefaceStandard} not supported!";
            }

            int batteryLevelSum = currRobots.Sum(b => b.BatteryLevel);

            if (batteryLevelSum < totalPowerNeeded)
            {
                return $"{serviceName} cannot be executed! {totalPowerNeeded - batteryLevelSum} more power needed.";
            }

            int robotsCount = 0;

            foreach (var robot in currRobots)
            {                    
                robotsCount++;

                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    break;
                }

                totalPowerNeeded -= robot.BatteryLevel;

                robot.ExecuteService(robot.BatteryLevel);
                
            }

            return $"{serviceName} is performed successfully with {robotsCount} robots.";
        }

        public string RobotRecovery(string model, int minutes)
        {
            var feedRobots = robots.Models()
                .Where(m => m.Model == model && m.BatteryCapacity / 2 > m.BatteryLevel);

            int feedetRobotsCount = 0;

            foreach (var robot in feedRobots)
            {
                feedetRobotsCount++;
                robot.Eating(minutes);
            }

            return $"Robots fed: {feedetRobotsCount}";
        }
        public string Report()
        {
           var orderedRoboRepo = robots.Models()
                .OrderByDescending(b => b.BatteryLevel)
                .ThenBy(b => b.BatteryCapacity);

            StringBuilder sb = new StringBuilder();

            foreach (var robot in orderedRoboRepo)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
