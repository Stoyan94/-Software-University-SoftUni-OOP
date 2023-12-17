using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> universityRepor;

        public UniversityRepository()
        {
            universityRepor = new List<IUniversity>();
        }
        public void AddModel(IUniversity model) => universityRepor.Add(model);
        public IUniversity FindById(int id)
        {
            var currUniversity = universityRepor.FirstOrDefault(s => s.Id == id);

            if (currUniversity == null)
            {
                return null;
            }

            return currUniversity;
        }

        public IReadOnlyCollection<IUniversity> Models => universityRepor.AsReadOnly();


        public IUniversity FindByName(string name)
        {
            var currUniversity = universityRepor.FirstOrDefault(n => n.Name == name);

            if (currUniversity == null)
            {
                return null;
            }

            return currUniversity;
        }
    }
}
