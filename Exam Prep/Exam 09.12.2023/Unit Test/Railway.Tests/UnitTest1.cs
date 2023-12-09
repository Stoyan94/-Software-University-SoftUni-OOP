namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
       
        [Test]
        public void ConstructorInitialize()
        {
            RailwayStation railwayStation = new RailwayStation("go");
            railwayStation.NewArrivalOnBoard("train");

            Assert.AreEqual(railwayStation.Name, "go");
            Assert.That(railwayStation.ArrivalTrains.Contains("train"));
           
        }

        [Test]

        public void NameCannotBeNullOrWhiteSpice()
        {         

            Assert.Throws<ArgumentException>(() =>
            {
                RailwayStation railwayStation = new RailwayStation(null);
            }, "Not enough available memory to install the app.");

            Assert.Throws<ArgumentException>(() =>
            {
                RailwayStation railwayStation = new RailwayStation("   ");
            }, "Not enough available memory to install the app.");
        }

        [Test]

        public void TrainHasArrivedShouldAddToDepartureTrains()
        {
            RailwayStation railwayStation = new RailwayStation("go");
            railwayStation.NewArrivalOnBoard("train");

            Assert.AreEqual(railwayStation.TrainHasArrived("train"), $"train is on the platform and will leave in 5 minutes.");
            Assert.IsTrue(railwayStation.DepartureTrains.Contains("train"));
        }

        [Test]

        public void TrainHasArrivedShouldNotAddDepartureTrains()
        {
            RailwayStation railwayStation = new RailwayStation("go");
            railwayStation.NewArrivalOnBoard("train");
            railwayStation.NewArrivalOnBoard("train1");

            Assert.AreEqual(railwayStation.TrainHasArrived("train1"), "There are other trains to arrive before train1.");
        }

        [Test]

        public void TrainHasLeft()
        {
            RailwayStation railwayStation = new RailwayStation("go");
            railwayStation.NewArrivalOnBoard("train");
            railwayStation.NewArrivalOnBoard("train1");
            railwayStation.TrainHasArrived("train");
            railwayStation.TrainHasArrived("train1");

            Assert.IsFalse(railwayStation.TrainHasLeft("train1"));
            Assert.IsTrue(railwayStation.TrainHasLeft("train"));
        }
    }
}