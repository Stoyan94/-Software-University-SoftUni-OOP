using EDriveRent.Models;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<Route>
    {
        private readonly ICollection<Route> routeRepository;

        private RouteRepository()
        {
            routeRepository = new List<Route>();
        }
        public void AddModel(Route model)
        {
            routeRepository.Add(model);
        }

        public Route FindById(string identifier)
        {
            var currUser = routeRepository.FirstOrDefault(u => u == identifier);

            if (currUser is null)
            {
                return null;
            }

            return currUser;
        }

        public IReadOnlyCollection<Route> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
