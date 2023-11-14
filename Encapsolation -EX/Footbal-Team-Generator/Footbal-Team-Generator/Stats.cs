using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footbal_Team_Generator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
		{
			get => endurance; 
			private set 
			{ 
				if (this.IsStatInvalid(value))
				{
					throw new ArgumentException(string.Format(ExceptionMessages.InvalidStats,nameof(Endurance)));
				}
				endurance = value; 
			}
		}
        public int Sprint
        {
            get => sprint;
            private set
            {
                if (this.IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStats, nameof(Sprint)));
                }
                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            private set
            {
                if (this.IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStats, nameof(Dribble)));
                }
                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            private set
            {
                if (this.IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStats, nameof(Passing)));
                }
                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            private set
            {
                if (this.IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStats, nameof(Shooting)));
                }
                shooting = value;
            }
        }


        private bool IsStatInvalid(int value)
			=> value < 0 || value > 100;
    }
	
}
