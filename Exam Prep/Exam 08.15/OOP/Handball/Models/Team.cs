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
        private int pointsEarned;
        private string name;
        private readonly ICollection<IPlayer> players;

        public Team(string name)
        {
            this.Name = name;
            this.pointsEarned = 0;
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

        public int PointsEarned => pointsEarned;

        public double OverallRating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }
                return Math.Round(players.Average(x => x.Rating), 2);
            }
        }

        public IReadOnlyCollection<IPlayer> Players => (IReadOnlyCollection<IPlayer>)players;

        public void Draw()
        {
            this.pointsEarned += 1;

            var goalKeeper = players.FirstOrDefault(x => x.GetType().Name == "Goalkeeper");



            goalKeeper.IncreaseRating();
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
            this.pointsEarned += 3;

            foreach (var player in players)
            {
                player.IncreaseRating();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Team: {this.Name} Points: {this.PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            sb.Append($"--Players: ");

            if (this.Players.Any())
            {
                var names = this.Players.Select(p => p.Name);
                sb.Append(string.Join(", ", names));
            }
            else
            {
                sb.Append("none");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
