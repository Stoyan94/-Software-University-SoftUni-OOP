using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Xml.Linq;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planetsRepo;
        public Controller()
        {
            planetsRepo = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {
           if (planetsRepo.FindByName(name) != null)
           {
                return $"Planet {name} is already added!";
           }

           IPlanet planet = new Planet(name, budget);

            planetsRepo.AddItem(planet);
            return $"Successfully added Planet: {name}";
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            if (planetsRepo.FindByName(planetName) == null)
            {
                return $"Planet {planetName} does not exist!";
            }

            if (unitTypeName != nameof(AnonymousImpactUnit) && 
                unitTypeName != nameof(SpaceForces) && 
                unitTypeName != nameof(StormTroopers))
            {
               throw new InvalidOperationException($"{unitTypeName} still not available!");
            }            

            if (planetsRepo.Models.Any(a=>a.Army.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }

            IPlanet planet = this.planetsRepo.FindByName(planetName);

            IMilitaryUnit unit;

            if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else
            {
                unit = new AnonymousImpactUnit();
            }

           planet.Spend(unit.Cost);
           planet.AddUnit(unit);

            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planetsRepo.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            if (weaponTypeName != nameof(BioChemicalWeapon) &&
                weaponTypeName != nameof(NuclearWeapon) &&
                weaponTypeName != nameof(SpaceMissiles))
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }

            IWeapon weapon;

            if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return $"{planetName} purchased {weaponTypeName}!";
        }
        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planetsRepo.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            else if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException("No units available for upgrade!");
            }
            else
            {
                double specializeCost = 1.25;
                planet.TrainArmy();
                planet.Spend(specializeCost);

                return $"{planetName} has upgraded its forces!";
            }
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planetsRepo.FindByName(planetOne);
            IPlanet secondPlanet = planetsRepo.FindByName(planetTwo);

            double firstPlanetHalfBudget = firstPlanet.Budget / 2;
            double secondPlanetHalfBudget = secondPlanet.Budget / 2;

            double firstCalculatedValue = firstPlanet.Army.Sum(x => x.Cost) +
                                            firstPlanet.Weapons.Sum(y => y.Price);

            double secondCalculatedValue = secondPlanet.Army.Sum(x => x.Cost) +
                                            secondPlanet.Weapons.Sum(y => y.Price);

            double firstPowerRatio = firstPlanet.MilitaryPower;
            double secondPowerRatio = secondPlanet.MilitaryPower;

            bool firstHasNuclear = firstPlanet.Weapons
                .Any(w => w.GetType().Name == nameof(NuclearWeapon));

            bool secondHasNuclear = secondPlanet.Weapons
                .Any(w => w.GetType().Name == nameof(NuclearWeapon));

            var firstNuclear = firstPlanet.Weapons
                .FirstOrDefault(w => w.GetType().Name == nameof(NuclearWeapon));
            var secondNuclear = secondPlanet.Weapons
                .FirstOrDefault(w => w.GetType().Name == nameof(NuclearWeapon));

            if (firstPowerRatio > secondPowerRatio)
            {
                firstPlanet.Spend(firstPlanetHalfBudget);
                firstPlanet.Profit(secondPlanetHalfBudget);
                firstPlanet.Profit(secondCalculatedValue);

                planetsRepo.RemoveItem(secondPlanet.Name);
                return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else if (firstPowerRatio < secondPowerRatio)
            {
                secondPlanet.Spend(secondPlanetHalfBudget);
                secondPlanet.Profit(firstPlanetHalfBudget);
                secondPlanet.Profit(firstCalculatedValue);

                planetsRepo.RemoveItem(firstPlanet.Name);
                return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }
            else
            {
                if (firstNuclear != null && secondNuclear != null)
                {                    
                    firstPlanet.Spend(firstPlanetHalfBudget);
                    secondPlanet.Spend(secondPlanetHalfBudget);
                    return string.Format(OutputMessages.NoWinner);                   
                }
                else if (firstNuclear != null)
                {
                    firstPlanet.Spend(firstPlanetHalfBudget);
                    firstPlanet.Profit(secondPlanetHalfBudget);
                    firstPlanet.Profit(secondCalculatedValue);

                    planetsRepo.RemoveItem(secondPlanet.Name);
                    return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                else if (secondNuclear != null)
                {
                    secondPlanet.Spend(secondPlanetHalfBudget);
                    secondPlanet.Profit(firstPlanetHalfBudget);
                    secondPlanet.Profit(firstCalculatedValue);

                    planetsRepo.RemoveItem(firstPlanet.Name);
                    return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
                else
                {
                    firstPlanet.Spend(firstPlanetHalfBudget);
                    secondPlanet.Spend(secondPlanetHalfBudget);
                    return string.Format(OutputMessages.NoWinner);
                }
            }
        }
        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in this.planetsRepo.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
