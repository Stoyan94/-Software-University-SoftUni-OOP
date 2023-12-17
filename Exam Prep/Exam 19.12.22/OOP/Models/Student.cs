﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        private string firstName;
        private string lastName;

        private List<IUniversity> universityList;

        private List<int> coveredExamsID;

        public Student(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;

           universityList = new List<IUniversity>();
            coveredExamsID = new List<int>();
        }
        public int Id { get; private set; }


        public string FirstName
        {
            get => firstName; private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName; private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams => coveredExamsID.AsReadOnly();

        //TODO: FINISH UNIVERSITY
        public IUniversity University => throw new NotImplementedException();

        public void CoverExam(ISubject subject)
        {
            coveredExamsID.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            university
        }
    }
}
