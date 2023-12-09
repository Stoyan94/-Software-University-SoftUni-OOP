using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models.DiverModels
{
    public class ScubaDiver : Diver
    {
        private const int ScubaDiverOxygenLevel = 540;
        private int ScubaDiverStartValue = 540;
        public ScubaDiver(string name) 
            : base(name, ScubaDiverOxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            double calcTime = TimeToCatch * 0.30;

            base.OxygenLevel -= (int)Math.Round(calcTime, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy() => base.OxygenLevel = ScubaDiverStartValue;
    }
}
