using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ICollection<User> userRepository;

        private UserRepository()
        {
            userRepository = new List<User>();
        }
        public void AddModel(User model)
        {
            userRepository.Add(model);
        }

        public User FindById(string identifier)
        {
            var currUser = userRepository.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);

            if (currUser is null)
            {
                return null;
            }

            return currUser;
        }

        public IReadOnlyCollection<User> GetAll() 
            => (IReadOnlyCollection<User>) userRepository;
        

        public bool RemoveById(string identifier)
        {
            var currUser = userRepository.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);

            if (currUser is null)
            {
                return false;
            }
            return true;
        }
    }
}
