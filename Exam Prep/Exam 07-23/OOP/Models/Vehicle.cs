using System;
using System.Diagnostics.Metrics;
using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private double maxMileage;
        private string licensePlateNumber;
        private int batteryLevel;
        private bool isDamaged;

        protected Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
            this.BatteryLevel = 100;
        }

        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                brand = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                model = value;
            }
        }

        public double MaxMileage
        {
            get => maxMileage;
            private set
            {

                maxMileage = value;
            }
        }

        public string LicensePlateNumber
        {
            get => licensePlateNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                licensePlateNumber = value;
            }
        }

        public int  BatteryLevel
        {
            get => batteryLevel;
            private set
            {
                batteryLevel = value;
            }
        }

        public bool IsDamaged
        {
            get => isDamaged;
            private set
            {
                isDamaged = value;
            }
        }

        public void ChangeStatus()
        {
            this.IsDamaged = isDamaged ? false : true;
        }

        public void Drive(double mileage)
        {
            this.BatteryLevel -= (int)Math.Round(mileage / MaxMileage * 100);

            //Anytime you find yourself writing code of the
            //form "if the object is of type T1, then do
            //something, but if it's of type T2, then do
            //something else ", slap yourself.

            //From Effective  by Scott Meyers

            //this check breaks the rule,
            //but that's how the task was written by the creator

            if (this.GetType() == typeof(CargoVan))
            {
                this.batteryLevel -= 5;
            }
           
        }

        public void Recharge()
        {
            this.batteryLevel = 100;
        }

        public override string ToString()
        {
            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {(IsDamaged ? "damaged" : "OK")}";
        }
    }
}
