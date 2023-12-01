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
            var existingTeam = team.FirstOrDefault(p => p.Name == name);

            if (existingTeam is null)
            {
                return false;
            }
            return true;
        }

        public ITeam GetModel(string name)
        {
            var returnTeam = team.FirstOrDefault(p => p.Name == name);

            if (returnTeam is null)
            {
                return null;
            }
            return true;
        }

        public bool RemoveModel(string name)
        {
            throw new NotImplementedException();
        }
    }
}
