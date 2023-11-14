using System;

namespace PersonsInfo
{
    public class Person
    {
        private const int MinAgeBouns = 30;

        private string firstName;
        private string lasttName;
        private int age;
        private decimal salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            this.Salary = salary;
        }

        public string FirstName 
        {
            get => firstName;
            private set
            {
                if (value.Length < ExceptionMessages.MinDigitsNames)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.FirstName, ExceptionMessages.MinDigitsNames));
                }
                firstName = value;
            }
        }
        public string LastName 
        {
            get => lasttName; 
            private set
            {
                if (value.Length < ExceptionMessages.MinDigitsNames)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.LastName, ExceptionMessages.MinDigitsNames));
                }
                lasttName = value;
            } 
        }
        public int Age
        {
            get => age;
            private set 
            {
                if (value <= ExceptionMessages.MinAge)
                {
                    throw new ArgumentException(ExceptionMessages.AgeZero);
                }
                age = value; 
            }
        }
        public decimal Salary
        {
            get => salary; 
            private set 
            {
                if (value < ExceptionMessages.MinSalary)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.Salary, ExceptionMessages.MinSalary));
                }
                salary = value; 
            }
        }
               
        public decimal IncreaseSalary(decimal percentage) => age < MinAgeBouns
            ? this.Salary += this.Salary * (percentage / 200)
            : this.Salary += this.Salary * (percentage / 100);


        public override string ToString()
            => $"{FirstName} {LastName} receives {salary:f2} leva.";


    }
}
