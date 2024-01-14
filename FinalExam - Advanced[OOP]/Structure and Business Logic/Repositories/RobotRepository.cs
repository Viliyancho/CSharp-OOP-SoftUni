using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private readonly List<IRobot> robots;

        public RobotRepository()
        {
            robots = new List<IRobot>();
        }
        public void AddNew(IRobot model)
        {
            robots.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            foreach (var robot in robots)
            {
                foreach (var item in robot.InterfaceStandards)
                {
                    if(item == interfaceStandard)
                    {
                        return robot;
                    }
                }
            }
            return null;
        }

        public IReadOnlyCollection<IRobot> Models()
        {
            return robots.AsReadOnly();
        }

        public bool RemoveByName(string typeName)
        {
            IRobot first = robots.FirstOrDefault(r=>r.Model == typeName);
            if(first == null)
            {
                return false;
            }
            robots.Remove(first);
            return true;
        }
    }
}
