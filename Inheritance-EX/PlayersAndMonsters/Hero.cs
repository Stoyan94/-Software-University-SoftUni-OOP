﻿namespace PlayersAndMonsters
{
    public class Hero
    {
        public Hero(string userName, int level)
        {
            UserName = userName;
            Level = level;
        }

        public string UserName { get; set; }
        public int Level { get; set; }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.UserName} Level: {this.Level}";
        }
    }
}
