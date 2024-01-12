using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories;
using System;
using System.Linq;
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
            throw new System.NotImplementedException();
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
