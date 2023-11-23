using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [TestCase(10, 10)]
        public void AxeShouldInitlizeWithCorrectValues(int expectedAtack, int expcetedDirability)
        {
            Axe axe = new Axe(10, 10);
            Assert.AreEqual(expectedAtack, axe.AttackPoints);
            Assert.AreEqual(expcetedDirability, axe.DurabilityPoints);
        }



        [TestCase(1, 9)]
        [TestCase(9, 1)]

        public void AtackMethodShouldDecreaseAtackDirability(int atackCounts, int expectedDirability)
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(100, 10);

            for (int i = 0; i < atackCounts; i++)
            {
                axe.Attack(dummy);
            }
            Assert.AreEqual(expectedDirability, axe.DurabilityPoints);

        }

        [TestCase(10)]
      

        public void AtackMethodShouldThrowExceptionBrokenAxe(int atackCounts)
        {
            Axe axe = new Axe(5, 10);
            Dummy dummy = new Dummy(100, 10);

            for (int i = 0; i < atackCounts; i++)
            {
                axe.Attack(dummy);
            }

            Assert.Throws<InvalidOperationException>(
                () => axe.Attack(dummy), "Axe is broken.");
        }

        //[TestCase(3)]
        //[TestCase(9)]

        //public void AtackMethodShouldDecreaseAtackDirability(int atackCounts)
        //{
        //    Axe axe = new Axe(10,10);

        //    Dummy dummy = new Dummy(10, 10);


        //    for (int i = 0; i < atackCounts; i++)
        //    {            
        //        dummy.TakeAttack(1);
        //    }


        //}
    }
}