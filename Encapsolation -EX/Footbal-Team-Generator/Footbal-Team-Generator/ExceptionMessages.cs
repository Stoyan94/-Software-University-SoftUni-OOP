using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footbal_Team_Generator
{
    public static class ExceptionMessages
    {
        public const string InvalidName = "A name should not be empty.";

        public const string InvalidStats = "{0} should be between 0 and 100.";

        public const string MissingPlayer = "Player {0} is not in {1} team.";

        public const string InvalidTeamName = "Team {0} does not exist.";
    }
}
