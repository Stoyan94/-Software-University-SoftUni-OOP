using NUnit.Framework;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace RobotFactory.Tests
{
    public class Tests
    {
        [Test]
        public void RobotFactoryConstructorShouldInitializeCorrectly()
        {
            string expectedName = "Tesla";
            int expectedCap = 10;

            Factory factory = new Factory(expectedName, expectedCap);

            Assert.AreEqual(expectedName, factory.Name);
            Assert.AreEqual(expectedCap, factory.Capacity);
            Assert.NotNull(factory.Robots);
            Assert.NotNull(factory.Supplements);
        }

        [Test]

        public void ProduceRobotMethodShouldWorkCorrectly()
        {
            Factory factory = new Factory("Tesla", 10);

            Assert.AreEqual(factory.ProduceRobot("Pika", 55, 1), $"Produced --> Robot model: Pika IS: 1, Price: 55.00");
        }

        [Test]

        public void ProduceRobotMethodShouldThrowExceptionCapacityIsMax()
        {
            Factory factory = new Factory("Tesla", 1);

            Robot robot = new Robot("Pika", 55, 1);

            factory.ProduceRobot("Pika", 55, 1);

            Assert.AreEqual(factory.ProduceRobot("Pika", 55, 1), "The factory is unable to produce more robots for this production day!");
            Assert.True(factory.Robots.Any(x => x.Model == robot.Model));
        }

        [Test]

        public void ProduceSupplementMethodShouldAddSupplementToRobotAndReturSuppToString()
        {
            Factory factory = new Factory("Tesla", 1);

            Robot robot = new Robot("Pika", 55, 1);

            string expectedNameSup = "Laser";
            int expectedStandardNum = 7;

            Supplement supplement = new Supplement(expectedNameSup, expectedStandardNum);

            Assert.AreEqual(factory.ProduceSupplement(expectedNameSup, expectedStandardNum), "Supplement: Laser IS: 7");
        }

        [Test]

        public void UpgradeRobotShouldAddSuppToRobotAndReturTrue()
        {
            Factory factory = new Factory("Tesla", 10);

            Robot robot = new Robot("Pika", 55, 7);

            factory.ProduceRobot(robot.Model,robot.Price,7);

            Supplement supplement = new Supplement("Lazer", 7);                              

            Assert.IsTrue(factory.UpgradeRobot(robot, supplement));
        }

        [Test]

        public void UpgradeRobotShouldAddSuppToRobotAndReturFalse()
        {
            Factory factory = new Factory("Tesla", 10);

            Robot robot = new Robot("Pika", 55, 1);

            factory.ProduceRobot(robot.Model, robot.Price, 7);

            Supplement supplement = new Supplement("Lazer", 5);    
            robot.Supplements.Add(supplement);

            Assert.IsFalse(factory.UpgradeRobot(robot, supplement));
        }

        [Test]

        public void SellRobotMethodShouldReturRobotsWithSamePrice()
        {
            Factory factory = new Factory("Tesla", 10);

            Robot expectedRobot = new("Pika", 700, 24);

            factory.ProduceRobot(expectedRobot.Model, expectedRobot.Price, expectedRobot.InterfaceStandard);
            factory.ProduceRobot("Pikachu", 1000, 25);
            factory.ProduceRobot("Ash", 500, 26);


            Robot actualRobot = factory.SellRobot(800);

            Assert.AreEqual(expectedRobot.Model, actualRobot.Model);
            Assert.AreEqual(expectedRobot.InterfaceStandard, actualRobot.InterfaceStandard);
            Assert.AreEqual(expectedRobot.Price, actualRobot.Price);
        }

        [Test]
        public void SellRobotShouldReturnNullIfPriceIsTooLow()
        {
            Factory factory = new Factory("Tesla", 10);

            Robot expectedRobot = new("Pika", 700, 24);

            factory.ProduceRobot(expectedRobot.Model, expectedRobot.Price, expectedRobot.InterfaceStandard);
            factory.ProduceRobot("Pikachu", 1000, 25);
            factory.ProduceRobot("Ash", 500, 26);

            Robot actualRobot = factory.SellRobot(20);

            Assert.Null(actualRobot);
        }

        [Test]
        public void SellRobotShouldReturnNullIfRobotsCollectionIsEmpty()
        {
            Factory factory = new Factory("Tesla", 10);

            Robot actualRobot = factory.SellRobot(20);

            Assert.Null(actualRobot);
        }
    }
}