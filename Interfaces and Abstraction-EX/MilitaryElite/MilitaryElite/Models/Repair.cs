namespace MilitaryElite.Models
{
    using Interfaces;

    public class Repair : IRepair
    {
        public Repair(string partName, int houesWorked)
        {
            this.PartName = partName;
            this.HouesWorked = houesWorked;
        }

        public string PartName { get; private set; }

        public int HouesWorked { get; private set; }
    }
}
