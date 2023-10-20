using Wild_Farm.Core.Interfaces;
using Wild_Farm.IO.Interfaces;

namespace Wild_Farm.Core
{    
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }
    }
}
