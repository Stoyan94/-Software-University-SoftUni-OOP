using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Objects
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string name, string lastName, decimal salary, IReadOnlyCollection<IPrivate> privates)
            : base(id, name, lastName, salary)
        {
            Privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates { get; private set; }


        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(base.ToString())
                  .AppendLine("Privates:");

            foreach (var currPrivate in Privates)
            {
                output.AppendLine($"  {currPrivate.ToString()}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
