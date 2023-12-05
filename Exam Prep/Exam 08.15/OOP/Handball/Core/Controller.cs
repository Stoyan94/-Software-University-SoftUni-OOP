﻿using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;
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

        public Controller()
        {
            this.players = new PlayerRepository();
            this.teams = new TeamRepository();
        }
        public string LeagueStandings()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***League Standings***");

            foreach (var team in this.teams.Models.OrderByDescending(t => t.PointsEarned).ThenByDescending(t => t.OverallRating).ThenBy(t => t.Name))
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string NewContract(string playerName, string teamName)
        {
            if (!this.players.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, nameof(PlayerRepository));
            }

            if (!this.teams.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, nameof(TeamRepository));
            }

            IPlayer player = players.GetModel(playerName);
            ITeam team = teams.GetModel(teamName);

            if (player.Team != default)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }

            player.JoinTeam(teamName);
            team.SignContract(player);

            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = this.teams.GetModel(firstTeamName);
            ITeam secondTeam = this.teams.GetModel(secondTeamName);

            if (firstTeam.OverallRating != secondTeam.OverallRating)
            {
                ITeam winner;
                ITeam loser;
                if (firstTeam.OverallRating > secondTeam.OverallRating)
                {
                    winner = firstTeam;
                    loser = secondTeam;
                }
                else
                {
                    winner = secondTeam;
                    loser = firstTeam;
                }

                winner.Win();
                loser.Lose();

                return string.Format(OutputMessages.GameHasWinner, winner.Name, loser.Name);
            }
            else
            {
                firstTeam.Draw();
                secondTeam.Draw();

                return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);
            }
        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName != "Goalkeeper" && typeName != "CenterBack" && typeName != "ForwardWing")
            {
                return $"{typeName} is invalid position for the application.";
            }

            var addPlayer = players.GetModel(name);

            if (addPlayer != null)
            {
                return $"{name} is already added to the {nameof(PlayerRepository)} as {addPlayer.GetType().Name}.";
            }

            IPlayer newPlayer = null;

            if (typeName == "Goalkeeper")
            {
                newPlayer = new Goalkeeper(name);
            }
            else if (typeName == "CenterBack")
            {
                newPlayer = new CenterBack(name);
            }
            else if (typeName == "ForwardWing")
            {
                newPlayer = new ForwardWing(name);
            }

            players.AddModel(newPlayer);

            return $"{name} is filed for the handball league.";
        }

        public string NewTeam(string name)
        {
            if (this.teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, nameof(TeamRepository));
            }

            this.teams.AddModel(new Team(name));
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, nameof(TeamRepository));
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***{teamName}***");

            ITeam team = this.teams.GetModel(teamName);

            foreach (var player in team.Players.OrderByDescending(p => p.Rating).ThenBy(p => p.Name))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}