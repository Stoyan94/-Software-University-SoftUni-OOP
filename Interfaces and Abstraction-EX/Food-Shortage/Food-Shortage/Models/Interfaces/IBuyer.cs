namespace Food_Shortage.Models.Interfaces
{
    public interface IBuyer : INameble
    {
        public int Food { get; }
        public void BuyFood();
    }
}
