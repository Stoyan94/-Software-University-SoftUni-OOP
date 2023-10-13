using Food_Shortage.Core.Interfaces;
using Food_Shortage.IO;
using Food_Shortage.IO.Interfaces;

namespace Food_Shortage.Core
{
    public class Engine : IEngie
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader consoleReader, IWriter consoleWriter)
        {
            this.reader = consoleReader;
            this.writer = consoleWriter;
        }

        public void Run()
        {
          
        }
    }
}
