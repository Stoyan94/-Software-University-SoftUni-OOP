using System;

namespace PersonsInfo;

public class StartUp
{
    static void Main(string[] args)
    {
        int players = int.Parse(Console.ReadLine());

        Team team = new Team("SoftUni");

        for (int i = 0; i < players; i++)
        {
            string[] input = Console.ReadLine().Split();

            string firstName = input[0];
            string lastName = input[1];
            int age = int.Parse(input[2]);
            decimal salary = decimal.Parse(input[3]);

            Person person = new Person(firstName, lastName, age, salary);

            team.Add(person);
        }
    }
}