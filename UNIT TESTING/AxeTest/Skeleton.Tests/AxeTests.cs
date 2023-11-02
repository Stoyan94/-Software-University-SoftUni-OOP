using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]

        public void AxeShouldInitlizeWithCorrectValues()
        {
            //Aarange and act
            Axe axe = new Axe(100, 100);
            Assert.AreEqual(100, axe.DurabilityPoints);
            Assert.AreEqual(100, axe.AttackPoints);
        }

        [Test]
        public void AtackMethodShouldDecreaseDurabilityPoint()
        {
            //Arrange
            Dummy target = new Dummy(10, 10);
            Axe axe = new Axe(100, 10);

            //Act
            axe.Attack(target);

            //Assert
            Assert.AreEqual(9, axe.DurabilityPoints);
        }

        [Test]
        public void AtackMethodShouldThrowExceptionIfDurabilityIsZero() 
        {
            //Arrange
            Dummy target = new Dummy(100, 100);
            Axe axe = new Axe(10, 10);

            //Act
            for (int i = 0; i < 10; i++)
            {
                axe.Attack(target);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => axe.Attack(target), "Axe is broken."); 

            
        }
    }
}