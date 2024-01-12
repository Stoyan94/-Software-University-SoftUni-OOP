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

        public string ForcesReport()
        {
            throw new System.NotImplementedException();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            throw new System.NotImplementedException();
        }

        public string SpecializeForces(string planetName)
        {
            throw new System.NotImplementedException();
        }
    }
}
