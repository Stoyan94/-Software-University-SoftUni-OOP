using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private readonly ICollection<IUser> userRepository;

        private UserRepository()
        {
            userRepository = new List<IUser>();
        }
        public void AddModel(IUser model)
        {
            userRepository.Add(model);
        }

        public IUser FindById(string identifier)
        {
            var currUser = userRepository.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);

            if (currUser is null)
            {
                return null;
            }

            return currUser;
        }

        public IReadOnlyCollection<IUser> GetAll() 
            => (IReadOnlyCollection<IUser>) userRepository;
        

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
