using MilitaryElite.Models.Enums;
using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Objects
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string name, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IRepair> repaers)
            : base(id, name, lastName, salary, corps)
        {
            Repaers = repaers;
        }

        public IReadOnlyCollection<IRepair> Repaers { get; private set; }


        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(base.ToString());           
            output.AppendLine("Repairs:");

            foreach(var repaerPart in Repaers)
            {
                output.AppendLine($"  {repaerPart.ToString()}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
