using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string name;
        private readonly ICollection<IPlayer> players;

        public Team(string name)
        {
            this.Name = name;
            PointsEarned = 0;
            players = new List<IPlayer>();
        }

        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.TeamNameNull);
                }
                name = value;
            }
        }

        public int PointsEarned { get; private set; }

        public double OverallRating => Math.Round(players.Average(x=>x.Rating), 2);

        public IReadOnlyCollection<IPlayer> Players => (IReadOnlyCollection<IPlayer>)players;

        public void Draw()
        {
            PointsEarned -= 1;

            var goalKeeper = players.FirstOrDefault(x => x.GetType().Name == "Goalkeeper");

            goalKeeper.DecreaseRating();
        }

        public void Lose()
        {          
            foreach (var player in players)
            {
                player.DecreaseRating();                
            }
        }

        public void SignContract(IPlayer player)
        {
            players.Add(player);
        }

        public void Win()
        {
            PointsEarned += 3;

            foreach (var player in players)
            {
                player.IncreaseRating();
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Team: {Name} Points: {PointsEarned}");
            output.AppendLine($"--Overall rating: {OverallRating}:F2");

            if (players.Count == 0)
            {
                return "--Players: none";
            }

            foreach (var player in players)
            {          
                output.Append($"Players: {player.Name}, {player}");
            }


            return output.ToString().TrimEnd();
        }
    }
}
