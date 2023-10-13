using Food_Shortage.Core.Interfaces;
using Food_Shortage.IO;
using Food_Shortage.IO.Interfaces;
using Food_Shortage.Models;
using Food_Shortage.Models.Interfaces;
using System.Collections.Generic;

namespace Food_Shortage.Core
{
    public class Engine : IEngie
    {
        private IReader reader;
        private IWriter writer;
        
        private HashSet<INameble> society;

        public Engine(IReader consoleReader, IWriter consoleWriter)
        {
            this.reader = consoleReader;
            this.writer = consoleWriter;
            society = new HashSet<INameble>();
        }

        public void Run()
        {
            int numPeopels = int.Parse(reader.ReadLine());
            
            for (int i = 0; i < numPeopels; i++)
            {
                string[] input = reader.ReadLine().Split(" ",
                    System.StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                INameble person = null;

                if (input.Length == 4)
                {
                    person = new Citizen(name, age, input[2], input[3]);
                    society.Add(person);
                }
                else
                {
                    person = new Rebel(name, age, input[2]);
                    society.Add(person);
                }


            }

            string command;

            while ((command = reader.ReadLine())!="End")
            {

            }
        }
    }
}
