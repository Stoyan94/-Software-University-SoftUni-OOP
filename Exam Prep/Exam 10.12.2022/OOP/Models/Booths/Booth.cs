using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
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
        private DelicacyRepository delicacies;
        private CocktailRepository cocktails;

        public Booth(int boothId, int capacity)
        {
            this.BoothId = boothId;
            this.Capacity = capacity;
            CurrentBill = 0;
            Turnover = 0;
            delicacies = new DelicacyRepository();
            cocktails = new CocktailRepository();
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
        public IRepository<IDelicacy> DelicacyMenu => delicacies;

        public IRepository<ICocktail> CocktailMenu => cocktails;

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

            foreach (var cocktail in cocktails.Models)
            {
                output.AppendLine($"--{cocktail}");
            }

            foreach (var delicacy in delicacies.Models)
            {
                output.AppendLine($"--{delicacy}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
