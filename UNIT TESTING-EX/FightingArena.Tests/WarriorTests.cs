namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [SetUp] public void SetUp() 
        {
        }

        
        [Test]
        public void ConstructorShouldInitializeWarriorName()
        {
            //Arrange
            string expectedName = "Pesho";

            Warrior warrior = new Warrior(expectedName, 50, 50);

            string actualName = warrior.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        //[TestCase(50)]
        //[TestCase(100000)]
        //[TestCase(1)]
        [Test]
        public void ConstructorShouldInitializeWarriorDamage()
        {
            int exppectedDame = 50;

            Warrior warrior = new Warrior("Pesho", exppectedDame, 50);

            int actualDamage = warrior.Damage;

            Assert.AreEqual(exppectedDame, actualDamage);
        }

        //[TestCase(100)]
        //[TestCase(50)]
        //[TestCase(1)]
        //[TestCase(0)]
        [Test]
        public void ConstructorShouldInitializeWarriorHP()
        {
            int exppectedHP = 100;

            Warrior warrior = new Warrior("Pesho", 50, exppectedHP);

            int actualHP = warrior.HP;

            Assert.AreEqual(exppectedHP, actualHP);
        }

        [TestCase("Pesho")]
        [TestCase("W")]
        [TestCase("Very very very very very very very very long name")]
        public void NameSetterShouldSetValueWithValidNames(string name)
        {
            Warrior warrior = new Warrior(name, 50, 50);

            string expectedName = name;
            string actualName = warrior.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void NameSetterShouldThrowExceptionWithEmptyOrWhiteSpaceName(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 50, 100);
            }, "Name should not be empty or whitespace!");
        }
    }
}