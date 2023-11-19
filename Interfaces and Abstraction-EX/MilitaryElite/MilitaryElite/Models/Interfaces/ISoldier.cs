using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Interfaces
{
    public interface ISoldier
    {
        string Name { get; }
        string LastName { get; }
        int Id { get; }
    }
}
