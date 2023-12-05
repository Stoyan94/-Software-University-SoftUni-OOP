using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    { 
        private int boothId;
        private int capacity;
         

        public Booth(int boothId, int capacity)
        {
            this.BoothId = boothId;
            this.Capacity = capacity;
        }
        public int BoothId { get => boothId; private set => boothId = value; }
        public int Capacity
        {
            get => capacity; 
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }

        //TODO : REPORS
        public IRepository<IDelicacy> DelicacyMenu => throw new NotImplementedException();

        public IRepository<ICocktail> CocktailMenu => throw new NotImplementedException();

        public double CurrentBill => throw new NotImplementedException();

        public double Turnover => throw new NotImplementedException();

        public bool IsReserved => throw new NotImplementedException();

        public void ChangeStatus()
        {
            throw new NotImplementedException();
        }

        public void Charge()
        {
            throw new NotImplementedException();
        }

        public void UpdateCurrentBill(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
