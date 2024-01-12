using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private UnitRepository units;
        private WeaponRepository weapons;
        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }
        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Planet name cannot be null or empty.");
                }
                name = value;
            }
        }

        public double Budget
        {
            get => budget; private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget's amount cannot be negative.");
                }
                budget = value;
            }
        }

        public double MilitaryPower => Math.Round(this.CalculateMilitaryPower(), 3);
        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit) => units.AddItem(unit);    

        public void AddWeapon(IWeapon weapon) => weapons.AddItem(weapon);

        public void TrainArmy() => Army.Select(e=>e.EnduranceLevel + 1);

        public void Spend(double amount)
        {
            if (amount > Budget)
            {
                throw new ArgumentException("Budget too low!");
            }
            Budget -= amount;
        }

        public void Profit(double amount) => Budget += amount;

        public string PlanetInfo()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Planet: {this.Name}");
            output.AppendLine($"--Budget: {this.budget} billion QUID");

            foreach (var currUnit in Army)
            {
                if (Army.Count == 0)
                {
                    output.Append($"--Forces: No units");
                    break;
                }
                output.Append($"--Forces: {currUnit.GetType().Name}");
            }

            foreach (var currWeapon in Weapons)
            {
                if (Weapons.Count == 0)
                {
                    output.Append($"--Combat equipment: No weapons");
                    break;
                }
                output.Append($"--Combat equipment: {currWeapon.GetType().Name}");
            }

            output.AppendLine($"--Military Power: {Army.Sum(e=>e.EnduranceLevel)}");

            return output.ToString().TrimEnd();
        }


        private double CalculateMilitaryPower()
        {
            double result = this.units.Models.Sum(x => x.EnduranceLevel) + this.weapons.Models.Sum(x => x.DestructionLevel);

            if (this.units.Models.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                result *= 1.3;
            }
            if (this.weapons.Models.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                result *= 1.45;
            }

            return result;
        }
    }
}
