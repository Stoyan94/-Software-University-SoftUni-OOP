using BirthdayCelebrations.Core.Interface;
using BirthdayCelebrations.IO.Interfaces;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations.Core
{
    public class Engine : IEngine
    {
        private List<IBirthable> liveOrganisms;
        private List<IIdentifiable> robots;

        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            liveOrganisms = new List<IBirthable>();
            robots = new List<IIdentifiable>();
        }

        public void Run()
        {
            string input;

            while ((input = reader.ReadLine())!= "End")
            {
                string[] splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = splitInput[0];
                
                if (type == "Citizen")
                {
                    IBirthable citizen = new Human(splitInput[3], splitInput[1], int.Parse(splitInput[2]), splitInput[4]);
                    liveOrganisms.Add(citizen);
                }
                else if (type == "Pet")
                {
                    IBirthable pet = new Pet(splitInput[1], splitInput[2]);
                    liveOrganisms.Add(pet);
                }
                else if (type == "Robot")
                {
                    IIdentifiable robot = new Robot(splitInput[1], splitInput[0]);
                    robots.Add(robot);
                }               

            }

            string birthMatch = reader.ReadLine();

            bool isPetFound = false;

            foreach (var organism in liveOrganisms)
            {
                if (organism.BirthDate.EndsWith(birthMatch))
                {
                    writer.WriteLine(organism.BirthDate);
                    isPetFound = true;
                }
            }

            if (!isPetFound)
            {
                writer.WriteLine("<empty output>");
            }
        }
    }
}
