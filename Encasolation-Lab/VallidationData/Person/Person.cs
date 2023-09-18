﻿using System;
namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (value.Length <3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                firstName = value;
            }
        }
        public string LastName 
        {
            get => lastName;
            private set 
            {
                if (value.Length <3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                lastName = value;
            } 
        }
        public int Age 
        {
            get => age; 
            private set 
            {
                if (value <=0)
                {
                   throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                age = value;
            }            
        }
        public decimal Salary 
        { 
            get => salary; 
            private set 
            {
                if (value <650)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                salary = value;
            } 
        }

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public override string ToString()
        => $"{this.firstName} {this.lastName} receives {this.salary:f2} leva.";

        public void IncreaseSalary(decimal percentage)
        {
            if (this.age > 30)
                this.salary += this.salary * percentage / 100;
            else
                this.salary += this.salary * percentage / 200;
        }
    }
}
