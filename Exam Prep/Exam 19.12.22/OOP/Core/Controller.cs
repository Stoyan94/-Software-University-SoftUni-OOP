using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Models.Subjects;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private IRepository<ISubject> subjectRepository;
        private IRepository<IStudent> studentRepository;
        private IRepository<IUniversity> universityRepository;

        public Controller()
        {
            subjectRepository = new SubjectRepository();
            studentRepository = new StudentRepository();
            universityRepository = new UniversityRepository();
        }
        public string AddSubject(string subjectName, string subjectType)
        {        

            if (subjectType != nameof(EconomicalSubject) && subjectType != nameof(HumanitySubject) && subjectType != nameof(TechnicalSubject))
            {
                return $"Subject type {subjectType} is not available in the application!";
            }
            else if (subjectRepository.FindByName(subjectName) != null)
            {
                return $"{subjectName} is already added in the repository.";
            }

            ISubject subject = null;

            int subjectID = subjectRepository.Models.Count + 1;

            if (subjectType == nameof(EconomicalSubject))
            {
                subject = new EconomicalSubject(subjectID, subjectName);
            }
            else if (subjectType == nameof(HumanitySubject))
            {
                subject = new HumanitySubject(subjectID, subjectName);
            }
            else if (subjectType == nameof(TechnicalSubject))
            {
                subject = new TechnicalSubject(subjectID, subjectName);
            }

            subjectRepository.AddModel(subject);

            return $"{subjectType} {subjectName} is created and added to the {nameof(SubjectRepository)}!";
        }
        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universityRepository.FindByName(universityName) != null)
            {
                return $"{universityName} is already added in the repository.";
            }

            int universityID = universityRepository.Models.Count + 1;

            ICollection<int> subjectsID = new List<int>();


            foreach (var needetSubj in requiredSubjects)
            {
                foreach (var subject in subjectRepository.Models)
                {
                    if (needetSubj == subject.Name)
                    {
                        subjectsID.Add(subject.Id);
                    }
                }
            }           

            IUniversity university = new University(universityID, universityName, category, capacity, subjectsID);

            universityRepository.AddModel(university);

            return $"{universityName} university is created and added to the {nameof(UniversityRepository)}!";
        }
        public string AddStudent(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public string TakeExam(int studentId, int subjectId)
        {
            throw new NotImplementedException();
        }
        public string ApplyToUniversity(string studentName, string universityName)
        {
            throw new NotImplementedException();
        }


        public string UniversityReport(int universityId)
        {
            throw new NotImplementedException();
        }
    }
}
