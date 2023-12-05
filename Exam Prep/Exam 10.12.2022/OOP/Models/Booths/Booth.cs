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
            CurrentBill = 0;
            Turnover = 0;
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

        public double CurrentBill { get; private set; }

        public double Turnover { get; private set; }

        public bool IsReserved => false;

        public void ChangeStatus()
        {
           bool isStatusChange = IsReserved ? false : true;
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }

        //TODO: FINISH TOSTRING
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Booth: {boothId}").
                AppendLine($"Capacity: {Capacity}").
                AppendLine($"Turnover: {Turnover:F2} lv").
                AppendLine("-Cocktail menu:");

            return null;
        }
    }
}
