using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private string name;
        private string category;
        private int capacity;

       
        public University(int id, string name, string category, int capacity , ICollection<int> requiredSubjectsID)
        {
            Id = id;
            Name = name;
            Category = category;
            Capacity = capacity;

            RequiredSubjects = (IReadOnlyCollection<int>)requiredSubjectsID;
        }
        public int Id { get; private set; }


        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public string Category
        {
            get => category; 
            private set
            {
                if (value.ToLower() != "technical" && value.ToLower() != "economical" && value.ToLower() != "humanity")
                {
                    throw new AggregateException($"University category {value} is not allowed in the application!");
                }
                category = value;
            }
        }

        public int Capacity
        {
            get => capacity; 
            private set
            {
                if (value < 0 )
                {
                    throw new ArgumentException("University capacity cannot be a negative value!");
                }
                capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects { get; private set; }
    }
}
