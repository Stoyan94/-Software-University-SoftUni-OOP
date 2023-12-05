using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IBooth> boothRepository;
        private readonly IRepository<IDelicacy> delicacyRepository;
        private readonly IRepository<ICocktail> cocktailRepository;

        public Controller()
        {
            boothRepository = new BoothRepository();
            delicacyRepository = new DelicacyRepository();
            cocktailRepository = new CocktailRepository();
        }
        public string AddBooth(int capacity)
        {
            var boothId = boothRepository.Models.Count + 1;           
            var booth = new Booth(boothId,capacity);

            return $"Added booth number {boothId} with capacity {capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != "Hibernation" && cocktailTypeName != "MulledWine")
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }
            else if (size != "Small" && size != "Middle" && size != "Large")
            {
                return $"{size} is not recognized as valid cocktail size!";
            }

            var isCocktailExist = cocktailRepository.Models.Any(c => c.Name == cocktailName && c.Size == size);

            if (isCocktailExist)
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }

            ICocktail addCocktail = null;

            if (cocktailTypeName == "Hibernation")
            {
                addCocktail = new Hibernation(cocktailName, size);
            }
            else if(cocktailTypeName == "MulledWine")
            {
                addCocktail = new MulledWine(cocktailName, size);

            }

            cocktailRepository.AddModel(addCocktail);

            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != "Gingerbread" && delicacyTypeName != "Stolen")
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }

            var isDelicacyExist = delicacyRepository.Models.Any(x => x.Name == delicacyName);

            if (isDelicacyExist)
            {
                return $"{delicacyName} is already added in the pastry shop!";
            }

            IDelicacy addDelicacy = null;

            if (delicacyTypeName == "Gingerbread")
            {
                addDelicacy = new Gingerbread(delicacyName);                
            }
            else if (delicacyTypeName != "Stolen")
            {
                addDelicacy = new Stolen(delicacyName);
            }

            delicacyRepository.AddModel(addDelicacy);

            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
        }

        public string BoothReport(int boothId)
        {
            throw new NotImplementedException();
        }

        public string LeaveBooth(int boothId)
        {
            throw new NotImplementedException();
        }

        public string ReserveBooth(int countOfPeople)
        {
            throw new NotImplementedException();
        }

        public string TryOrder(int boothId, string order)
        {
            throw new NotImplementedException();
        }
    }
}
