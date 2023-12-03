using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IPlayer> players;
        private readonly IRepository<ITeam> teams;
        public string LeagueStandings()
        {
            throw new NotImplementedException();
        }

        public string NewContract(string playerName, string teamName)
        {
            var searchPlayer = players.GetModel(playerName);

            if (searchPlayer == null)
            {
                return $"Player with the name {playerName} does not exist in the {nameof(PlayerRepository)}.";
            }

            var searchTeam = teams.GetModel(teamName);

            if (searchTeam == null)
            {
                return $"Team with the name {teamName} does not exist in the {GetType().Name}.";
            }

            if (searchPlayer.Team != null)
            {
                return $"Player {playerName} has already signed with {searchPlayer.Team}.";
            }

            players.AddModel(searchPlayer);

            return $"Player {playerName} signed a contract with {teamName}.";
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            var teamOne = teams.GetModel(firstTeamName);
            var teamTwo = teams.GetModel(secondTeamName);

            if (teamOne.OverallRating > teamTwo.OverallRating)
            {
                teamOne.Win();
                teamTwo.Lose();

                return $"Team {firstTeamName} wins the game over {secondTeamName}!";
            }
            else if (teamTwo.OverallRating > teamOne.OverallRating)
            {
                teamTwo.Win();
                teamOne.Lose();

                return $"Team {firstTeamName} wins the game over {secondTeamName}!";
            }
            
              teamOne.Draw();
              teamTwo.Draw();            

            return $"The game between {firstTeamName} and {secondTeamName} ends in a draw!";
        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName != "Goalkeeper" || typeName != "CenterBack" || typeName != "ForwardWing")
            {
                return $"{typeName} is invalid position for the application.";
            }

            var addPlayer = players.GetModel(name);

            if (addPlayer != null)
            {
                return $"{name} is already added to the {GetType().Name} as {typeName}.";
            }

            players.AddModel(addPlayer);

            return $"{name} is filed for the handball league.";
        }

        public string NewTeam(string name)
        {
            var addTeam = teams.GetModel(name);

            if (addTeam is not null)
            {
                return $"{name} is already added to the {GetType().Name}.";
            }

            teams.AddModel(addTeam);

            return $"{name} is successfully added to the {GetType().Name}.";
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new StringBuilder();

            var teamInfo = teams.GetModel(teamName);

            sb.AppendLine($"***{teamName}***");

            foreach (var player in teamInfo.Players.OrderByDescending(r => r.Rating).OrderBy(n => n.Name))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
