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

       
        [Test]
        public void ConstructorShouldInitializeWarriorDamage()
        {
            int exppectedDame = 50;

            Warrior warrior = new Warrior("Pesho", exppectedDame, 50);

            int actualDamage = warrior.Damage;

            Assert.AreEqual(exppectedDame, actualDamage);
        }
      
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

        [TestCase(100)]
        [TestCase(50)]
        [TestCase(1)]        
        public void DamageSetterShouldSetValueWithValidDamage(int damage)
        {
            Warrior warrior = new Warrior("Pesho", damage, 100);

            int expectedDamage = damage;
            int actualDamage = warrior.Damage;

            Assert.AreEqual(expectedDamage, actualDamage);
        }

        [TestCase(-50)]
        [TestCase(-1)]
        [TestCase(0)]
        public void DamageSetterShouldThrowExceptionWithZeroOrNegativeDame(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", damage, 100);
            }, "Damage value should be positive!");
        }

        [TestCase(50)]
        [TestCase(100000)]
        [TestCase(1)]
        [TestCase(0)]
        public void HpSetterShouldSetValueWithValidHP(int hp)
        {
            Warrior warrior = new Warrior("peshho", 50, hp);

            int expectedHP = hp;
            int actualHP = warrior.HP;

            Assert.AreEqual(expectedHP, actualHP);
        }

        [TestCase(-100)]
        [TestCase(-50)]
        [TestCase(-1)]       
        public void HPSetterShouldThrowExceptionWithNegativeHP(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("pesho", 50, hp);
            }, "HP should not be negative!");
        }

        [Test]

        public void SuccessAttackingWarriorNoKill()
        {
            int w1Damage = 50;
            int w1HP = 100;
            int w2Damage = 30;
            int w2HP = 100;

            Warrior w1 = new Warrior("stoqn", w1Damage, w1HP);
            Warrior w2 = new Warrior("pesho", w2Damage, w2HP);

            w1.Attack(w2);

            int w1ExpectedHP = w1HP - w2Damage;
            int w2ExpectedHP = w2HP - w1Damage;

            int w1ActualHP = w1.HP;
            int w2ActualHP = w2.HP;

            Assert.AreEqual(w1ExpectedHP, w1ActualHP);
            Assert.AreEqual(w2ExpectedHP, w2ActualHP);
        }
        
    
        [TestCase(35)]
        [TestCase(50)]        

        public void SuccessAttackingWarriorWithKill(int w2HP)
        {
            int w1Damage = 50;
            int w1HP = 100;
            int w2Damage = 30;           

            Warrior w1 = new Warrior("stoqn", w1Damage, w1HP);
            Warrior w2 = new Warrior("pesho", w2Damage, w2HP);

            w1.Attack(w2);

            int w1ExpectedHP = w1HP - w2Damage;
            int w2ExpectedHP = 0;

            int w1ActualHP = w1.HP;
            int w2ActualHP = w2.HP;

            Assert.AreEqual(w1ExpectedHP, w1ActualHP);
            Assert.AreEqual(w2ExpectedHP, w2ActualHP);
        }
    }
}