using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class ForwardWing : Player
    {
        private const double GoalkeeperDefaultRating = 5.5;

        public ForwardWing(string name)
            : base(name, GoalkeeperDefaultRating)
        {
        }

        public override void DecreaseRating() => this.Rating -= 0.75;

        public override void IncreaseRating() => this.Rating += 1.25;
    }
}
