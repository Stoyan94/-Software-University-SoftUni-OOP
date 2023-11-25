﻿using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private double rating;
        private string drivingLicenseNumber;
        private bool isBlocked;

        public User(string firstName, string lastName, double rating)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Rating = rating;
        }

        public string FirstName
        {
            get => firstName;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FirstNameNull);
                }
                firstName = value;
            }
        }

        public string LastName 
        {
            get => lastName;
            private set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }
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
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
                }
                drivingLicenseNumber = value;
            }
        }

        public bool IsBlocked
        {
            get => isBlocked; 
            private set
            {
                isBlocked = value;
            }
        }

        public void DecreaseRating()
        {
            this.Rating -= 2;

            if (this.rating < 0)
            {
                this.rating = 0;
                this.isBlocked = true;
            }          
        }

        public void IncreaseRating()
        {
            this.Rating += 0.5;

            if (this.Rating > 10)
            {
                this.Rating = 10;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Driving license: {drivingLicenseNumber} Rating: {rating}";
        }
    }
}
