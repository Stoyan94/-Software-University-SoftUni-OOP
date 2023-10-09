namespace MilitaryElite.Models
{
    using Enums;
    using Interfaces;
    using System.Collections.Generic;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly ICollection<IMission> missions;
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new HashSet<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions 
            => (IReadOnlyCollection<IMission>)this.missions;
    }
}
