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
using UniversityCompetition.Utilities.Messages;

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
            if (studentRepository.Models.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                return $"{firstName} {lastName} is already added in the repository.";
            }

            int studentID = studentRepository.Models.Count + 1;

            IStudent student = new Student(studentID, firstName, lastName);

            studentRepository.AddModel(student);

            return $"Student {firstName} {lastName} is added to the {nameof(StudentRepository)}!";
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (studentRepository.FindById(studentId) == null)
            {
                return $"Invalid student ID!";
            }

            if (subjectRepository.FindById(subjectId) == null)
            {
                return $"Invalid subject ID!";
            }
                
            IStudent student = studentRepository.FindById(studentId);

            if (studentRepository.FindById(studentId).CoveredExams.Any(s=>s == subjectId))
            {

                return $"{student.FirstName} {student.LastName} has already covered exam of {subjectRepository.FindById(subjectId).Name}.";
            }
            
            ISubject subject = subjectRepository.FindById(subjectId);
            student.CoverExam(subject);

            return $"{student.FirstName} {student.LastName} covered {subject.Name} exam!";
        }
        public string ApplyToUniversity(string studentName, string universityName)
        {           
            string[] splitName = studentName.Split();

            string firstName = splitName[0];          
            string lasttName = splitName[1];

            var student = studentRepository.FindByName(studentName);
            var university = universityRepository.FindByName(universityName);

            if (student == null)
            {
                return $"{firstName} {lasttName} is not registered in the application!";
            }
            else if (university == null)
            {
                return $"{universityName} is not registered in the application!";
            }
            else if (!university.RequiredSubjects.All(r => student.CoveredExams.Any(e => e == r)))
            {
                return $"{studentName} has not covered all the required exams for {universityName} university!";
            }
            else if (student.University != null && student.University.Name == universityName)
            {
                return $"{firstName} {lasttName} has already joined {universityName}.";
            }            
               
            student.JoinUniversity(university);
               
            return $"{firstName} {lasttName} joined {universityName} university!";
        }


        public string UniversityReport(int universityId)
        {
            var university = this.universityRepository.FindById(universityId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {studentRepository.Models.Where(s => s.University == university).Count()}");
            sb.AppendLine($"University vacancy: {university.Capacity - studentRepository.Models.Where(s => s.University == university).Count()}");

            return sb.ToString().TrimEnd();
        }
    }
}
