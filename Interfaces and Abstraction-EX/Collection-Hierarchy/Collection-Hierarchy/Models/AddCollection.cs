using Collection_Hierarchy.Models.Interfaces;
using System.Collections.Generic;

namespace Collection_Hierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        private readonly List<string> data;

        public AddCollection()
        {
            this.data = new List<string>();
        }
        public int Add(string item)
        {
           data.Add(item);

            return this.data.Count - 1;
        }
    }
}
