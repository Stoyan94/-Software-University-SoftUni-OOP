using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Employee employee = new Employee("Stoyan");

            IList<string> list = new List<string>();
            list.Add("CEO");

            Manager manager = new Manager("Stoyan", list);

            List<Employee> list2 = new List<Employee>();
            list2.Add(employee);
            list2.Add(manager);

            DetailsPrinter newDetail = new DetailsPrinter(list2);
            newDetail.PrintDetails();
            
        }
    }
}
