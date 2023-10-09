namespace MilitaryElite.Models
{ 
    using Interfaces;
    using System.Collections.Generic;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly ICollection<IPrivate> privates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = new HashSet<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates 
            => (IReadOnlyCollection<IPrivate>)this.privates;
    }
}
