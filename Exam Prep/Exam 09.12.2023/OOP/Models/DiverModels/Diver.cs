using NauticalCatchChallenge.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models.DiverModels
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;

        private List<string> catchFish;
        private double competitionPoints;

        public Diver(string name, int oxygenLevel)
        {
            this.Name = name;
            this.OxygenLevel = oxygenLevel;

            CompetitionPoints = 0;
            HasHealthIssues = false;
            catchFish = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Diver's name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int OxygenLevel
        {
            get => oxygenLevel; 
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                oxygenLevel = value;
            }
        }

        public IReadOnlyCollection<string> Catch => catchFish.AsReadOnly();

        public double CompetitionPoints { get => competitionPoints; private set => Math.Round(competitionPoints = value, 1); }

        public bool HasHealthIssues { get; private set; }

        public virtual void Hit(IFish fish)
        {
            this.oxygenLevel -= fish.TimeToCatch;
            catchFish.Add(fish.Name);
            this.CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
           if (HasHealthIssues == true)
           {
                HasHealthIssues = false;
           }
            else
            {
                HasHealthIssues = true;
            }
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints:f1} ]";
        }
    }
}
