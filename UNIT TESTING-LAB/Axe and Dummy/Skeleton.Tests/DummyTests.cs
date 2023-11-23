using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {

        [TestCase(10)]
        public void DummyShouldInitlizeWithCorrectValues(int expectedHealth)
        {
            Dummy dummy = new Dummy(expectedHealth, 10);

            Assert.AreEqual(expectedHealth, dummy.Health);
        }

        [Test]
        public void DummyShouldAtackCorrectly()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(9);
        }

        [Test]
        public void DummyShouldThrowExceptionWhenIsDead()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(11);

            Assert.Throws<InvalidOperationException>(
                () => dummy.TakeAttack(11), "Dummy is dead.");

        }

        [Test]

        public void GiveExprerienceMethodShouldReturExprerinceWhenDummyDie()
        {
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(11);

            int exptectedEXP = 10;


            Assert.AreEqual(exptectedEXP, dummy.GiveExperience());
        }

        [Test]
        public void GiveExpShouldThrowAnExceptionIfDummyIsNotDead()
        {            
            Dummy dummy = new Dummy(100, 100);

            dummy.TakeAttack(50);

            Assert.Throws<InvalidOperationException>(
                () => dummy.GiveExperience(),
                "Targer is not dead.");
        }

        [Test]

        public void IsDeadShouldChekIfHealthIsBelowOrEqualToZero()
        {            
            Dummy dummy = new Dummy(50, 100);

            dummy.TakeAttack(50);

            Assert.IsTrue(dummy.IsDead());
        }
    }
}