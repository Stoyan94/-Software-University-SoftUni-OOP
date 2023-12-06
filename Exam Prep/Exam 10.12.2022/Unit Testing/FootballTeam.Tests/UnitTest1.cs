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

            team.AddNewPlayer(player);
            team.AddNewPlayer(player2);

            Assert.AreEqual(expectedTeamName, team.Name);
            Assert.AreEqual(22, team.Capacity);
            Assert.True(team.Players.Contains(player));
            Assert.True(team.Players.Contains(player2));
            Assert.AreEqual(team.Players.Count, 2);
           
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
           

            FootballPlayer player = new FootballPlayer("stqon", 5, "Midfielder");          

           team.AddNewPlayer(player);

            Assert.AreEqual(team.AddNewPlayer(player), "Added player stqon in position Midfielder with number 5");
        }

        [Test]

        public void AddNewPlayerMethodShouldThrowExceptionWhenCapacityIsMax()
        {
            FootballTeam team = new FootballTeam("Manqci", 15);           

            FootballPlayer player = new FootballPlayer("stqon", 5, "Midfielder");

            for (int i = 0; i < 15; i++)
            {
                team.AddNewPlayer(player);
            }      

            Assert.AreEqual(team.AddNewPlayer(player), "No more positions available!");
        }


        [Test]

        public void PickPlayerMethodShouldReturPlayer()
        {
            FootballTeam team = new FootballTeam("Manqci", 15);            

            FootballPlayer player = new FootballPlayer("Stoqn", 5, "Midfielder");
            FootballPlayer player2 = new FootballPlayer("gosho", 5, "Midfielder");
            FootballPlayer playe3 = new FootballPlayer("joro", 5, "Midfielder");

            team.AddNewPlayer(player);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(playe3);

            Assert.AreEqual(team.PickPlayer("Stoqn"), player);
            Assert.AreEqual(team.PickPlayer("Gosho"), null);
        }


        [Test]

        public void PlayerScoreMethodShouldReturPlayerScoreCorrectly()
        {
            FootballTeam team = new FootballTeam("Manqci", 15);

            FootballPlayer player = new FootballPlayer("Stoqn", 5, "Midfielder");
            FootballPlayer player2 = new FootballPlayer("gosho", 5, "Midfielder");
            FootballPlayer playe3 = new FootballPlayer("joro", 5, "Midfielder");

            team.AddNewPlayer(player);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(playe3);
      

            Assert.AreEqual(team.PlayerScore(5), "Stoqn scored and now has 1 for this season!");
        }
    }
}