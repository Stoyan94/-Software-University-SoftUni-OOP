namespace Demos
{
    public class Stadium
    {
        private List<string> seats;


        public Stadium()
        {
            seats = new List<string>();
        }

        protected void Add(string seat)
        {
            seats.Add(seat);
        }

        public void Remove(string seat)
        {
            seats.Remove(seat);
        }
    }
}

