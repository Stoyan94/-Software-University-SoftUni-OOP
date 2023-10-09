using System;


namespace MilitaryElite.Models.Interfaces
{
    public interface ILieutenantGeneral : IPivate
    {
        IReadOnlyCollection<IPivate> Privates { get; }
    }
}
