using Food_Shortage.Models.Interfaces;

namespace Food_Shortage.Models
{
    public class Rebel : INameble, IBuyer
    {
        public Rebel(string name, int age, string groupName)
        {
            Name = name;
            Age = age;
            GroupName = groupName;
            Food = 0;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string GroupName { get; private set; }
        public int Food { get; private set; }
    }
}
