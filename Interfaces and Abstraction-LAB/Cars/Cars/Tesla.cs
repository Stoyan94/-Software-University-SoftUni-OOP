using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public int Battery { get; private set; }

        public string Start() => "Engine start";

        public string Stop() => $"Breaaak!";

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"{this.Color} {GetType().Name} {this.Model} with {this.Battery} Batteries");
            output.AppendLine(Start());
            output.AppendLine(Stop());

            return output.ToString().Trim();
        }
    }
}
