using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Team
    {
        private const int AgeSort = 40;

        private string teamName;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        private Team()
        {
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public Team(string teamName)
            : this()
        {
            this.TeamName = teamName;
        }


        public string TeamName { get; }
        public IReadOnlyCollection<Person> FirstTeam => firstTeam;
        public IReadOnlyCollection<Person> ReserveTeam => reserveTeam;


        public void AddPlayer(Person person)
        {
            if (person.Age < AgeSort)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }           
        }
       
    }
}
