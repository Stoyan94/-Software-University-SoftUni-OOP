namespace PersonsInfo
{
    public class Person
    {
        private int age;
        private decimal salary;
        private const int MinAge = 30;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            this.Salary = salary;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age 
        {
            get => age; 
            private set{ age = value; }
        }
        public decimal Salary 
        {
            get { return salary; }
            private set {salary = value; }
        }


        //public void IncreaseSalary(decimal percentage)
        //{
        //    if (age < MinAge)
        //    {
        //        percentage /= 2;
        //    }

        //    this.Salary += this.Salary *(percentage / 100);
            
        //}

        public decimal IncreaseSalary(decimal percentage) => age < MinAge
            ? this.Salary += this.Salary * (percentage / 200) 
            : this.Salary += this.Salary * (percentage / 100);

        
        public override string ToString( )
            => $"{FirstName} {LastName} receives {salary:f2} leva.";
        

    }
}
