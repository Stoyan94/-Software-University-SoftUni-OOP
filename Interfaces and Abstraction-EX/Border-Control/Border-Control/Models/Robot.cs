using Border_Control.Models.Interfaces;

namespace Border_Control.Models
{
    public class Robot : IIdentifiable
    {
        public Robot(string id, string model)
        {
            this.Id = id;
            this.Model = model;
        }

        public string Id { get; private set; }
        public string Model { get; private set; }
    }
}
