using Food_Shortage.Core.Interfaces;
using Food_Shortage.IO;
using Food_Shortage.IO.Interfaces;
using Food_Shortage.Models;
using Food_Shortage.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Food_Shortage.Core
{
    public class Engine : IEngie
    {
        private IReader reader;
        private IWriter writer;
        
        private ISet<IBuyer> buyers;
        

        public Engine(IReader consoleReader, IWriter consoleWriter)
        {
            this.reader = consoleReader;
            this.writer = consoleWriter;
            buyers = new HashSet<IBuyer>();            
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

                IBuyer person = null;

                if (input.Length == 4)
                {
                    person = new Citizen(name, age, input[2], input[3]);
                    buyers.Add(person);                   
                }
                else
                {
                    person = new Rebel(name, age, input[2]);
                    buyers.Add(person);                    
                }


            }

            string namePerson;

            while ((namePerson = reader.ReadLine())!="End")
            {
                buyers.FirstOrDefault(x=>x.Name ==  namePerson)?.BuyFood();
            }

            writer.ParsLine(buyers.Sum(b => b.Food));
        }
    }
}
