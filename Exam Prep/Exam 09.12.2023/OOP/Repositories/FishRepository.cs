using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Models.DiverModels;
using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Repositories
{
    public class FishRepository : IRepository<IFish>
    {
        private List<IFish> fishs;

        public FishRepository()
        {
            fishs = new List<IFish>();
        }
        public IReadOnlyCollection<IFish> Models => fishs.AsReadOnly();

        public void AddModel(IFish model) => fishs.Add(model);

        public IFish GetModel(string name)
        {
            var fish = fishs.FirstOrDefault(x => x.Name == name);

            if (fish == null)
            {
                return null;
            }

            return fish;
        }
    }
}
