using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void AxeShouldInitlizeWithCorrectValues()
        {
            //Arrange and act
            Dummy dummy = new Dummy(100,100);

            //Assert
            Assert.AreEqual(100, dummy.Health);           
        }

        [Test]

        public void TakeAtackShouldDecreaseHealth()
        {
            //Arrange
            Dummy dummy = new Dummy(100,100);

            //Act
            dummy.TakeAttack(50);

            //Assert
            Assert.AreEqual(50, dummy.Health);
        }

        [Test]
        public void TakeAtackShouldThrowExceptionIfDummyIsDead()
        {
            //Arrange
            Dummy dummy = new Dummy(100,100);

            //Act
            dummy.TakeAttack(50);
            dummy.TakeAttack(50);

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => dummy.TakeAttack(50),
                "Dummy is dead.");
        }

        [Test]
        
        public void GiveExpShouldReturnCurrentExperinceIfDummyIsDead()
        {
            //Arrange
            Dummy dummy = new Dummy(100, 100);

            //Act
            dummy.TakeAttack(50);
            dummy.TakeAttack(50);

            //Assert
            Assert.AreEqual(100, dummy.GiveExperience());
        }    
        
        [Test]
        
        public void GiveExpShouldThrowAnExceptionIfDummyIsNotDead()
        {
            //Arrange
            Dummy dummy = new Dummy(100, 100);

            //Act
            dummy.TakeAttack(50);
       
            //Assert
            Assert.Throws<InvalidOperationException>(
                () => dummy.GiveExperience(),
                "Targer is not dead.");
        }

        [Test]

        public void IsDeadShouldChekIfHealthIsBelowOrEqualToZero()
        {
            //Arrange
            Dummy dummy = new Dummy(50, 100);

            //Act
            dummy.TakeAttack(50);

            //Assert
            Assert.IsTrue(dummy.IsDead());
        }
    }
}