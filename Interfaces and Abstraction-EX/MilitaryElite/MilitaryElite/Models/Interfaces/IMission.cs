using MilitaryElite.Models.Enums;

namespace MilitaryElite.Models.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
