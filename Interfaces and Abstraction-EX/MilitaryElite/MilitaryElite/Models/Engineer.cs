namespace MilitaryElite.Models
{
    using Enums;
    using Interfaces;
    using System.Collections.Generic;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly ICollection<IRepair> repairs;
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new HashSet<IRepair>();
        }       

        public IReadOnlyCollection<IRepair> Repairs 
            => (IReadOnlyCollection<IRepair>)this.repairs;
    }
}
