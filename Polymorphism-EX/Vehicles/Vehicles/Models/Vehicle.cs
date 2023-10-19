using Vehicles.Models.Interfaces;
using System;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicel
    {
        private double increaseComps;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double increaseComps)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.increaseComps = increaseComps;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            double consumption = FuelConsumption + increaseComps;

            if (FuelQuantity < distance * consumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * consumption;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amout) =>  FuelQuantity += amout;

        public override string ToString() => $"{this.GetType().Name} {FuelQuantity:F2}";
    }
}
