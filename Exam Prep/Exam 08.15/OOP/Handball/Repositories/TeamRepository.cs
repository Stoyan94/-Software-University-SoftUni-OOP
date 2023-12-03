using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private readonly ICollection<ITeam> team;

        public TeamRepository()
        {
            this.team = new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models => (IReadOnlyCollection<ITeam>) team;

        public void AddModel(ITeam model)
        {
            team.Add(model);
        }

        public bool ExistsModel(string name)
        {
            var existingTeam = team.Any(p => p.Name == name);

            if (existingTeam)
            {
                return true;
            }
            return false;
        }

        public ITeam GetModel(string name)
        {
            var returnTeam = team.FirstOrDefault(p => p.Name == name);

            if (returnTeam is null)
            {
                return null;
            }

            return returnTeam;
        }

        public bool RemoveModel(string name)
        {
            var removePlayer = team.FirstOrDefault(p => p.Name == name);

            if (removePlayer is null)
            {
                return false;
            }

            team.Remove(removePlayer);
            return true;
        }
    }
}
