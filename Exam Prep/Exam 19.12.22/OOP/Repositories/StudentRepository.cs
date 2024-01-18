using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> studentRepor;

        public StudentRepository()
        {
            studentRepor = new List<IStudent>();
        }
        public void AddModel(IStudent model) => studentRepor.Add(model);
        public IStudent FindById(int id)
        {
            var currStudent = studentRepor.FirstOrDefault(s => s.Id == id);

            if (currStudent == null)
            {
                return null;
            }

            return currStudent;
        }

        public IReadOnlyCollection<IStudent> Models => studentRepor.AsReadOnly();


        public IStudent FindByName(string name)
        {
            string[] fullName = name.Split();

            string firstName = fullName[0];
            string lasttName = fullName[1];

            var currStudent = studentRepor.FirstOrDefault(n => n.FirstName == firstName && n.LastName == lasttName);

            if (currStudent == null)
            {
                return null;
            }

            return currStudent;
        }
    }
}
