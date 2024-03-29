﻿using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        public MilitaryUnit(double cost)
        {
            Cost = cost;
        }
        public double Cost { get; private set; }

        public int EnduranceLevel { get; private set; }

        public void IncreaseEndurance()
        {

            if (EnduranceLevel > 20)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.EnduranceLevelExceeded));

            }
            EnduranceLevel++;
        }
    }
}
