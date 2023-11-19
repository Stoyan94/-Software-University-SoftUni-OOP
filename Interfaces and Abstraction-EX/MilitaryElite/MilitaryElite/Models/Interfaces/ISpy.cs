using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Interfaces
{
    internal interface ISpy : ISoldier
    {
        public int CodeNumber { get; }
    }
}
