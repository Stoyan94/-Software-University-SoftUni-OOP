namespace Resturant.Models.Baverage
{
    public class Tea : HotBaverage
    {
        public Tea(string name, decimal price, double milliliters) 
            : base(name, price, milliliters)
        {}
    }
}
