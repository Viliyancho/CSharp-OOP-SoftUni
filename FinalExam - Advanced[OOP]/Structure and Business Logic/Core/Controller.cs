using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IRepository<ISupplement> supplements;
        private IRepository<IRobot> robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            if(typeName != nameof(DomesticAssistant) && typeName != nameof(IndustrialAssistant))
            {
                return String.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            IRobot robot;
            if(typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
                robots.AddNew(robot);
            }
            else
            {
                robot = new IndustrialAssistant(model);
                robots.AddNew(robot);
            }

            return String.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != nameof(SpecializedArm) && typeName != nameof(LaserRadar))
            {
                return String.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            ISupplement supplement;
            if (typeName == nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
                supplements.AddNew(supplement);
            }
            else
            {
                supplement = new LaserRadar();
                supplements.AddNew(supplement);
            }

            return String.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }


        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);
            int supplementInterfaceValue = supplement.InterfaceStandard;

            List<IRobot> their = new List<IRobot>();
            foreach (var item in robots.Models())
            {
                if(!item.InterfaceStandards.Contains(supplementInterfaceValue))
                {
                    their.Add(item);
                }
            }
            their.RemoveAll(x => x.Model != model);


            if(their.Count == 0)
            {
                return String.Format(OutputMessages.AllModelsUpgraded, model);
            }

            IRobot him = their.First();

            him.InstallSupplement(supplement);

            return String.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);

        }


        public string PerformService(string serviceName, int interfaceStandard, int totalPowerNeeded)
        {
            List<Robot> all = new List<Robot>();

            foreach (var robot in robots.Models())
            {
                if(robot.InterfaceStandards.Contains(interfaceStandard))
                {
                    all.Add((Robot)robot);
                }
            }

            if(all.Count == 0)
            {
                return String.Format(OutputMessages.UnableToPerform, interfaceStandard);
            }

            IOrderedEnumerable<Robot> everyone = all.OrderByDescending(x=>x.BatteryLevel);
            int sum = everyone.Sum(x=>x.BatteryLevel);

            if(sum < totalPowerNeeded)
            {
                return String.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sum);
            }

            int count = 0;

            foreach (var item in everyone)
            {
                if(item.BatteryLevel >= totalPowerNeeded)
                {
                    item.ExecuteService(totalPowerNeeded);
                    count++;
                    break;
                }
                else
                {
                    totalPowerNeeded -= item.BatteryLevel;
                    item.ExecuteService(item.BatteryLevel);
                    count++;
                }
            }

            return String.Format(OutputMessages.PerformedSuccessfully, serviceName, count);
        }
        public string RobotRecovery(string model, int minutes)
        {
            int count1 = 0;
            List<Robot> them = new List<Robot>();
            foreach (var item in robots.Models())
            {
                if(item.Model == model)
                {
                    them.Add((Robot)item);
                }
            }

            foreach (var item in them)
            {
                if(item.BatteryLevel < item.BatteryCapacity / 2)
                {
                    item.Eating(minutes);
                    count1++;
                }
            }

            return $"Robots fed: {count1}";
        }

        public string Report()
        {
            List<Robot> all = robots.Models()
                .OrderByDescending(x=>x.BatteryLevel)
                .ThenBy(x=>x.BatteryCapacity)
                .Select(x=>(Robot)x)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var robot in all)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
