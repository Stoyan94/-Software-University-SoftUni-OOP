using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Objects
{
   public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string name, string lastName)
        {
            Name = name;
            LastName = lastName;
            Id = id;
        }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int Id { get; private set; }

        public override string ToString()
            => $"Name: {this.Name} {this.LastName} Id: {this.Id} ";
        
    }
}
