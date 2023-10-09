
namespace MilitaryElite.Models
{
    using Enums;
    using Interfaces;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary , Corps corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = Corps;
        }

        public Corps Corps { get; private set; }
    }
}
