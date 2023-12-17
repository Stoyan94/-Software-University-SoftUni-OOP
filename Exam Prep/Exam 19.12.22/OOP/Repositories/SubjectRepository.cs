using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        private List<ISubject> subjectsRepor;

        public SubjectRepository()
        {
            subjectsRepor = new List<ISubject>();
        }
        public void AddModel(ISubject model) => subjectsRepor.Add(model);
        public ISubject FindById(int id)
        {
           var currSubject = subjectsRepor.FirstOrDefault(s => s.Id == id);

            if (currSubject == null)
            {
                return null;
            }

            return currSubject;
        }

        public IReadOnlyCollection<ISubject> Models => subjectsRepor.AsReadOnly();


        public ISubject FindByName(string name)
        {
            var currSubject = subjectsRepor.FirstOrDefault(n => n.Name == name);

            if (currSubject == null)
            {
                return null;
            }

            return currSubject;
        }
    }
}
