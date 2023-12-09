using NauticalCatchChallenge.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models.DiverModels
{
    public class FreeDiver : Diver
    {
        private const int FreeDiverOxygenLevel = 120;
        private int startValueFreeDiver = 120;
        public FreeDiver(string name) :
            base(name, FreeDiverOxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            double calcTime = TimeToCatch * 0.60;

            base.OxygenLevel -= (int)Math.Round(calcTime, MidpointRounding.AwayFromZero);
        }
        

        public override void RenewOxy() => base.OxygenLevel = startValueFreeDiver;
    }
}
