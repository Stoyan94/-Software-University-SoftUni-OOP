﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Goalkeeper : Player
    {
        private const double GoalkeeperDefaultRating = 2.5;
        public Goalkeeper(string name) 
            : base(name, GoalkeeperDefaultRating)
        {
        }

        public override void DecreaseRating() => this.Rating -= 1.25;

        public override void IncreaseRating() => this.Rating += 0.75;
        
    }
}
