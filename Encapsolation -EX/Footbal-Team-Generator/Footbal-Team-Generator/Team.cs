﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Footbal_Team_Generator
{
    public class Team
    {
		private string name;
        private List<Player> playersList;

        private Team()
        {
            this.playersList = new List<Player>();
        }
        public Team(string name) 
            : this() 
        {
            this.Name = name;
        }


        public string Name
		{
			get => name; 
			private set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }
                name = value; 
            }
		}

        public int Rating => this.playersList.Count > 0 ?
            (int)Math.Round(this.playersList.Average(p => p.AverageSkill), 0) : 0;

        public void AddPlayer(Player player) => this.playersList.Add(player);

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = this.playersList.FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingPlayer, playerName, this.Name));
            }
            this.playersList.Remove(playerToRemove);
        }


        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}
