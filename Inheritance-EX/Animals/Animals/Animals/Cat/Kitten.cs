namespace Animals.Animals.Cat
{
    public class Kitten : Cat
    {
        private const string KittenGender = "Female";
        public Kitten(string name, int age) 
            : base(name, age, KittenGender)
        {}

        public override string ProduceSound() => "Meow";
    }
}
