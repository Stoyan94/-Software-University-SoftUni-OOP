using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.Models.Animals
{
    public abstract class Mammal : Animal, IMammal
    {
        protected Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            livingRegion = LivingRegion;
        }

        public string LivingRegion { get; private set; }
    }
}
