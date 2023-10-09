using MilitaryElite.Models.Enums;

namespace MilitaryElite.Models.Interfaces
{
    public interface ISpecialisedSoldier : IPivate
    {
        Corps Corps { get; }
    }
}
