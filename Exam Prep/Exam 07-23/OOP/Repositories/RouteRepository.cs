using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private readonly ICollection<IRoute> routeRepository;

        private RouteRepository()
        {
            routeRepository = new List<IRoute>();
        }
        public void AddModel(IRoute model)
        {
            routeRepository.Add(model);
        }

        public IRoute FindById(string identifier)
        {
            var curRoute = routeRepository.FirstOrDefault(r => r.RouteId == int.Parse(identifier));

            if (curRoute is null)
            {
                return null;
            }

            return curRoute;
        }

        public IReadOnlyCollection<IRoute> GetAll()
          => (IReadOnlyCollection<IRoute>) routeRepository;
        public bool RemoveById(string identifier)
        {
            var curRoute = routeRepository.FirstOrDefault(u => u.RouteId == int.Parse(identifier));

            if (curRoute is null)
            {
                return false;
            }
            return true;
        }
    }
}
