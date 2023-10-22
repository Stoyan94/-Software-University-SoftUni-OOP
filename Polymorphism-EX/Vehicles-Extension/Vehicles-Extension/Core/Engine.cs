using Vehicles_Extension.Core.Interfaces;
using Vehicles_Extension.IO.Interfaces;

namespace Vehicles_Extension.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }
    }
}
