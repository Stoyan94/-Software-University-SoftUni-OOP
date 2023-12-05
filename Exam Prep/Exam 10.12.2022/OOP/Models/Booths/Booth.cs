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
        private double currentBill;
        private double turnover;

        private IRepository<IDelicacy> delicacies;
        private IRepository<ICocktail> cocktails;

        public Booth(int boothId, int capacity)
        {
            this.BoothId = boothId;
            this.Capacity = capacity;

            this.currentBill = 0;
            this.turnover = 0;

            delicacies = new DelicacyRepository();
            cocktails = new CocktailRepository();
        }
        public int BoothId { get => boothId; private set => boothId = value; }
        public int Capacity
        {
            get => capacity; 
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }
        public IRepository<IDelicacy> DelicacyMenu => delicacies;

        public IRepository<ICocktail> CocktailMenu => cocktails;

        public double CurrentBill => this.currentBill;

        public double Turnover => this.turnover;

        public bool IsReserved { get; private set; }

        public void ChangeStatus()
        {
            if (IsReserved)
            {
                IsReserved = false;
                return;
            }

            IsReserved = true;
        }

        public void Charge()
        {
            this.turnover += currentBill;
            this.currentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.currentBill += amount;
        }

        //TODO: FINISH TOSTRING
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Booth: {boothId}").
                AppendLine($"Capacity: {Capacity}").
                AppendLine($"Turnover: {Turnover:F2} lv").
                AppendLine("-Cocktail menu:");

            foreach (var cocktail in this.CocktailMenu.Models)
            {
                output.AppendLine($"--{cocktail}");
            }

            output.AppendLine($"-Delicacy menu:");

            foreach (var delicacy in this.DelicacyMenu.Models)
            {
                output.AppendLine($"--{delicacy}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
