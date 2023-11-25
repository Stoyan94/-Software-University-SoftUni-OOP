using EDriveRent.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private double rating;
        private string drivingLicenseNumber;

        public string FirstName
        {
            get => firstName;

            private set
            {
                firstName = value;
            }
        }

        public string LastName 
        {
            get => lastName;
            private set
            {
                lastName = value;
            }
        }

        public double Rating 
        { 
            get => rating;
            private set
            {
                rating = value;
            }
        }

        public string DrivingLicenseNumber 
        { 
            get => drivingLicenseNumber; 
            private set => drivingLicenseNumber = value; }

        public bool IsBlocked { get; private set; }

        public void DecreaseRating()
        {
            throw new NotImplementedException();
        }

        public void IncreaseRating()
        {
            throw new NotImplementedException();
        }
    }
}
