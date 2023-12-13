using BookingApp.Models.Rooms.Contracts;
using System;


namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight;

        protected Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;
            this.PricePerNight = pricePerNight;
        }
        public int BedCapacity { get => bedCapacity; private set => bedCapacity = value; }

        public double PricePerNight
        {
            get => pricePerNight; 
            private set
            {
                if (value < 0)
                {
                    pricePerNight = 0;

                    throw new ArgumentException("Price cannot be negative!");
                }
                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            pricePerNight = price;
        }
    }
}
