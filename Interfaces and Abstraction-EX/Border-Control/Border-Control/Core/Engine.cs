using Border_Control.Core.Interface;
using Border_Control.IO.Interfaces;
using Border_Control.Models;
using Border_Control.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Border_Control.Core
{
    public class Engine : IEngine
    {
        private List<IIdentifiable> society;

        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            society = new List<IIdentifiable>();
        }

        public void Run()
        {
            string input;

            while ((input = reader.ReadLine())!= "End")
            {
                string[] splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = splitInput[0];
                
                if (splitInput.Length == 3)
                {
                    IIdentifiable citizen = new Human(splitInput[2], name, int.Parse(splitInput[1]));
                    society.Add(citizen);
                }
                else
                {
                    IIdentifiable robot = new Robot(splitInput[1], splitInput[0]);
                    society.Add(robot);
                }               

            }

            string fakeId = reader.ReadLine();

            foreach (var organism in society)
            {
                if (organism.Id.EndsWith(fakeId))
                {
                    writer.WriteLine(organism.Id);
                }
            }
        }
    }
}
