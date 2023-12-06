using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FootballTeam.Tests
{
    public class Tests
    {        
        [Test]
        public void FootbalTeamConstructorShouldWorkCorrectly()
        {
            string expectedTeamName = "pokemons";
            int expectedTeamCap = 22;

            FootballTeam team = new FootballTeam(expectedTeamName, expectedTeamCap);

            List<FootballPlayer> players = new List<FootballPlayer>();

            FootballPlayer player = new FootballPlayer("stqon",5, "Midfielder");
            FootballPlayer player2 = new FootballPlayer("pesho",10, "Forward");

            players.Add(player);
            players.Add(player2);

            Assert.AreEqual(expectedTeamName, team.Name);
            Assert.AreEqual(22, team.Capacity);
            Assert.True(players.Contains(player));
            Assert.True(players.Contains(player2));
           
        }

        [Test]

        public void TeamCapacityShouldThrowExceptionWheNIsLessThen15()
        {
            string expectedTeamName = "pokemons";
            int expectedTeamCap = 14;            

            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(expectedTeamName, expectedTeamCap);
            }, "Capacity min value = 15");
        }

        [Test]

        public void TeamNameShouldThrowExceptioIsNullOrEmpty()
        {
            string expectedTeamName = "";
            string expectedTeamName1 = null;
            int expectedTeamCap = 14;

            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(expectedTeamName, expectedTeamCap);
            }, "Name cannot be null or empty!");

            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(expectedTeamName1, expectedTeamCap);
            }, "Name cannot be null or empty!");
        }


        [Test]

        public void AddNewPlayerMethodShouldWorkCorrectly()
        {
            FootballTeam team = new FootballTeam("Manqci", 15);

            List<FootballPlayer> players = new List<FootballPlayer>();

            FootballPlayer player = new FootballPlayer("stqon", 5, "Midfielder");
            FootballPlayer player2 = new FootballPlayer("pesho", 10, "Forward");

           team.AddNewPlayer(player);

            Assert.AreEqual(team.AddNewPlayer(player), "Added player stqon in position Midfielder with number 5");
        }

        [Test]

        public void AddNewPlayerMethodShouldThrowExceptionWhenCapacityIsMax()
        {
            FootballTeam team = new FootballTeam("Manqci", 15);

            List<FootballPlayer> players = new List<FootballPlayer>();

            FootballPlayer player = new FootballPlayer("stqon", 5, "Midfielder");

            for (int i = 0; i < 15; i++)
            {
                team.AddNewPlayer(player);
            }      

            Assert.AreEqual(team.AddNewPlayer(player), "No more positions available!");
        }
    }
}