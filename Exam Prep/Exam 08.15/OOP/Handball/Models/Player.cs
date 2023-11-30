using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string name;
        private double rating;
        private string team;

        protected Player(string name, double rating)
        {
            this.Name = name;
            this.Rating = rating;
            this.Team = team;
        }

        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }
                name = value;
            }
        }

        public double Rating
        {
            get => rating; 
            protected set
            {
                if (value > 10)
                {
                    rating = 10;
                }
                else if (value < 1)
                {
                    rating = 1;
                }
                rating = value;
            }
        }

        public string Team
        {
            get => team; 
            private set
            {
                team = value;
            }
        }

        public abstract void DecreaseRating();

        public abstract void IncreaseRating();

        public void JoinTeam(string name)
        {
            this.Team = name;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Name} {Environment.NewLine}--Rating: {Rating}";

        }
    }
}
