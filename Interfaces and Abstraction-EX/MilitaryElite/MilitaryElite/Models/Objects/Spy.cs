using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Objects
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string name, string lastName, int codeNumber)
            : base(id, name, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString() 
            => base.ToString() + $"{Environment.NewLine}Code Number: {CodeNumber}";
        
    }
}
