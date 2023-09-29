using ResturantExample.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantExample
{
    public class MoleucalarKitches : IOrderTaker
    {
        public void TakeOrder(string order)
        {
            Console.WriteLine($"Preparing order {order}");
            Console.WriteLine($"{order} dissappeared");
        }
    }
}
