using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private List<int> allowedInterfaceStandards;

        private string model;
        private int batteryCapacity;
        private int batteryLevel;
        private int convertionCapacityIndex;
        private IReadOnlyCollection<int> interfaceStandards;

        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            Model = model;
            BatteryCapacity= batteryCapacity;
            BatteryLevel = batteryCapacity;
            ConvertionCapacityIndex = conversionCapacityIndex;

            interfaceStandards = new List<int>();
            allowedInterfaceStandards = new List<int>();
        }
        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }
                model = value;
            }
        }

        public int BatteryCapacity
        {
            get { return batteryCapacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }
                batteryCapacity = value;
            }
        }

        public int BatteryLevel 
        {
            get { return  batteryLevel; }
            private set {  batteryLevel = value; }
        }


        public int ConvertionCapacityIndex
        {
            get { return convertionCapacityIndex; }
            private set { convertionCapacityIndex = value; }
        }


        

        public IReadOnlyCollection<int> InterfaceStandards
        {
            get { return allowedInterfaceStandards; }
        }


        public void Eating(int minutes)
        {
            int producedEnergy = ConvertionCapacityIndex * minutes;
            if(BatteryLevel + producedEnergy > BatteryCapacity)
            {
                BatteryLevel = BatteryCapacity;
            }
            else
            {
                BatteryLevel += producedEnergy;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            allowedInterfaceStandards.Add(supplement.InterfaceStandard);
            BatteryCapacity -= supplement.BatteryUsage;
            BatteryLevel -= supplement.BatteryUsage;
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if(BatteryLevel >= consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            if(InterfaceStandards.Count == 0)
            {
                sb.AppendLine("--Supplements installed: none");
            }
            else
            {
            sb.AppendLine($"--Supplements installed: {string.Join(" ", InterfaceStandards)}");
            }

                return sb.ToString().TrimEnd();
        }
    }
}
