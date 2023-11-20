using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double TruckIncreasedConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption, TruckIncreasedConsumption)
        {
        }

        public override void Refuel(double refuelLiters) 
            => base.Refuel(refuelLiters * 0.95);
        
    }
}
