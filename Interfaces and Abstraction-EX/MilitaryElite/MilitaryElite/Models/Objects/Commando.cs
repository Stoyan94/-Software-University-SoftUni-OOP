using MilitaryElite.Models.Enums;
using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Objects
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string name, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IMission> missions)
            : base(id, name, lastName, salary, corps)
        {
            Missions = missions;
        }

        public IReadOnlyCollection<IMission> Missions { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new();

            output.AppendLine(base.ToString());
            output.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                output.AppendLine($"  {mission.ToString()}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
