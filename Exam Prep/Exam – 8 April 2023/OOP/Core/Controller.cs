using RobotService.Core.Contracts;
using RobotService.Models.Contracts;
using RobotService.Models.RobotModels;
using RobotService.Models.SupplementModels;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            var currSupplement = supplemets.Models().
                FirstOrDefault(t => t.GetType().Name == supplementTypeName);

            var currRobot = robots.Models().FirstOrDefault(m => m.Model == model && 
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
            var currRobots = robots.Models().Where(i => i.InterfaceStandards.Contains(intefaceStandard)).
                OrderByDescending(b => b.BatteryLevel);

            if (currRobots is null)
            {
                return $"Unable to perform service, {intefaceStandard} not supported!";
            }

            int batteryLevelSum = currRobots.Sum(b => b.BatteryLevel);



            return null;
        }

        public string Report()
        {
            throw new NotImplementedException();
        }

        public string RobotRecovery(string model, int minutes)
        {
            throw new NotImplementedException();
        }

    }
}
