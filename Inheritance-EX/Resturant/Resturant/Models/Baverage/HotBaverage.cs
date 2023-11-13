namespace Resturant.Models.Baverage
{
    public abstract class HotBaverage : Baverage
    {  
        protected HotBaverage(string name, decimal price, double milliliters) 
            : base(name, price, milliliters)
        {
        }
    }
}
