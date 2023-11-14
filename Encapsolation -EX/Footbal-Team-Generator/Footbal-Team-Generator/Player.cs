using System;

namespace Footbal_Team_Generator
{
    public class Player
    {
		private string name;

        public Player(string name)
        {
            Name = name;
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

        public Stats Stats { get; private set; }

        public double AverageSkill => this.Stats.Endurance + this.Stats.Sprint +
			this.Stats.Dribble + this.Stats.Passing + this.Stats.Shooting / 5.0;

    }
}
