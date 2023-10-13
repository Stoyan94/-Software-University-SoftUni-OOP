using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Models
{
    public class Human : IIdentifiable, IBirthable
    {
        public Human(string id, string name, int age, string birthDate)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.BirthDate = birthDate;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public string BirthDate { get; private set; }
    }
}
