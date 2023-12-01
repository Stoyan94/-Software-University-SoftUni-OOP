using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly ICollection<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => (IReadOnlyCollection<IPlayer>) players;

        public void AddModel(IPlayer model)
        {
            players.Add(model);
        }

        public bool ExistsModel(string name)
        {
            var ExistingPlayer = players.FirstOrDefault(p => p.Name == name);

            if (ExistingPlayer is null)
            {
                return false;
            }
            return true;
        }

        public IPlayer GetModel(string name)
        {
            var returnPlayer = players.FirstOrDefault(p => p.Name == name);

            if (returnPlayer is null)
            {
                return null;
            }
            return returnPlayer;
        }
    

        public bool RemoveModel(string name)
        {
            var removePlayer = players.FirstOrDefault(p => p.Name == name);

            if (removePlayer is null)
            {
                return false;
            }

            players.Remove(removePlayer);
            return true;
        }
    }
}
