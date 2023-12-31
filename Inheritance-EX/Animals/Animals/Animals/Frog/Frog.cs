﻿using Animals.AbsClass;

namespace Animals.Animals.Frog
{
    public class Frog : Animal
    {
        public Frog(string name, int age, string gender)
            : base(name, age, gender)
        { }

        public override string ProduceSound() => "Ribbit";
    }
}
