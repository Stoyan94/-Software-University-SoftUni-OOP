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
        private ICollection<IPlayer> players;

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
            var existingPlayer = players.Any(p => p?.Name == name);

            if (existingPlayer)
            {
                return true;
            }
            return false;
        }

        public IPlayer GetModel(string name)
        {                      
            return players?.FirstOrDefault(p => p?.Name == name); 
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
