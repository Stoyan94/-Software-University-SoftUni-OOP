using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hero hero = new Hero("stoqn",99);

            Console.WriteLine(hero);
        }
    }
}