using RobotService.Models.Contracts;
using RobotService.Models.SupplementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models.RobotModels
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;       

        private readonly List<int> interfaceStandards;       
        protected Robot(string model, int batteryCapacity , int convertionCapacityIndex)
        {
            this.Model = model;
            this.BatteryCapacity = batteryCapacity;
            BatteryLevel = batteryCapacity;
            ConvertionCapacityIndex = convertionCapacityIndex;

            interfaceStandards = new List<int>();
        }

        public string Model
        {
            get => model; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Model cannot be null or empty.");
                }
                model = value;
            }
        }


        public int BatteryCapacity
        {
            get => batteryCapacity; 
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Battery capacity cannot drop below zero.");
                }
                batteryCapacity = value;
            }
        }

        public int BatteryLevel { get; private set; }

        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards.AsReadOnly();

        public void Eating(int minutes)
        {
           int totalCapacity = ConvertionCapacityIndex + minutes;

            if (totalCapacity < BatteryCapacity - BatteryLevel)
            {
                BatteryLevel = BatteryCapacity;
            }

            this.BatteryLevel += totalCapacity;
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (BatteryLevel >= consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;
                return true;
            }

            return false;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);
            BatteryCapacity -= supplement.BatteryUsage;
            BatteryLevel -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{GetType().Name} {Model}");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");


            string supplementInstaled = interfaceStandards.Any()
                ? $"{string.Join(" ", interfaceStandards)}"
                : "none";

            sb.AppendLine($"--Supplements installed: {supplementInstaled}");


          
            return sb.ToString().TrimEnd();
        }
    }
}
