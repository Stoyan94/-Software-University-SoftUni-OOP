using Collection_Hierarchy.Models.Interfaces;
using System.Collections.Generic;

namespace Collection_Hierarchy.Models
{
    public class MyList : IMyList
    {
        private const int AddIndex = 0;
        private const int RemoveIndex = 0;

        private readonly List<string> data;

        public MyList()
        {
            this.data = new List<string>();
        }
        public int Used => data.Count;

        public int Add(string item)
        {           
            data.Insert(AddIndex, item);

            return AddIndex;
        }

        public string Remove()
        {
            string item = data[RemoveIndex];

            data.RemoveAt(RemoveIndex);

            return item;
        }
    }
}
