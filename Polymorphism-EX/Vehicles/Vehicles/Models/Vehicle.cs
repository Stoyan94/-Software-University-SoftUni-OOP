using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double IncreasedConsumption;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double increasedConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.IncreasedConsumption = increasedConsumption;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            double consumption = FuelConsumption + IncreasedConsumption;

            if (FuelQuantity < distance * consumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * consumption;

            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double refuelLiters) 
            => this.FuelQuantity += refuelLiters;

        public override string ToString()
            => $"{GetType().Name}: {FuelQuantity:f2}";
    }
}
