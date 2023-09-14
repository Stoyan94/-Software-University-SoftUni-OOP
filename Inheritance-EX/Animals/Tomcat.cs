namespace Animals
{
    public class Tomcat : Cat
    {
        private const string TomcatGender = "Male";
        public Tomcat(string name, int age, string gender) 
            : base(name, age, TomcatGender)
        {
        }

        public override string ProduceSound() => "Meow meow";

    }
}
