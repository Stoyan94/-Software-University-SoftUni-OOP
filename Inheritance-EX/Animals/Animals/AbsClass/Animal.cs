using System;
using System.Text;

namespace Animals.AbsClass
{
    public abstract class Animal
    {
        private const string ExceptionMessage = "Invalid input!";

        private string name;
        private int age;
        private string gender;
        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name 
        {
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessage);
                }
                name = value;
            }
        }
        public int Age 
        {
            get => age; 
            private set
            {
                if (value <= 0)
                {                
                    throw new ArgumentException(ExceptionMessage);
                }
                age = value;
            }            
        }
        public string Gender 
        {
            get => gender; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessage);
                }
                gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(GetType().Name)
            .AppendLine($"{Name} {Age} {Gender}")
            .AppendLine(ProduceSound());

            return output.ToString().Trim();
        }

    }
}
