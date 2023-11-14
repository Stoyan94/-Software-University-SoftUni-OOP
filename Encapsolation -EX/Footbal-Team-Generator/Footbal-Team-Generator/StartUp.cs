using Footbal_Team_Generator;
using System;
using System.Collections.Generic;
using System.Linq;

List<Team> teamList = new List<Team>();

string input;

while ((input = Console.ReadLine()) != "END")
{
    string[] tokes = input.Split(";");

    string command = tokes[0];
    
    
    try
    {
        switch (command)
        {
            case "Team":
                AddTeam(tokes[1], teamList);
                break;            
            case "Add":
                string teamName = tokes[1];
                string playerName = tokes[2];
                int endurance = int.Parse(tokes[3]);
                int sprint = int.Parse(tokes[4]);
                int dribble = int.Parse(tokes[5]);
                int passing = int.Parse(tokes[6]);
                int shooting = int.Parse(tokes[7]);
                Add(teamName, playerName, endurance, sprint, dribble, passing, shooting, teamList);
                break;
            case "Remove":
                PlayerToRemove(tokes[1], tokes[2], teamList);
                break;
            case "Rating":
                PrintRating(tokes[1], teamList);
                break;
        }
    }
    catch (ArgumentException ex) 
    {
        Console.WriteLine(ex.Message);
    }
   
}


static void AddTeam(string teamName, List<Team> teamList)
{
    teamList.Add(new Team(teamName));
}
static void Add(string teamName, string playerName, int endurance, int sprint, int dribble, int passing, int shooting, List<Team> teamList)
{
    Team team = teamList.FirstOrDefault(n => n.Name == teamName);

    if (team == null)
    {
        throw new ArgumentException(string.Format(ExceptionMessages.InvalidTeamName, teamName));
    }
   
    Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
    team.AddPlayer(player); 
}
static void PlayerToRemove(string teamName, string playerName, List<Team> teamList)
{
    Team team = teamList.FirstOrDefault(n => n.Name == teamName);

    if (team == null)
    {
        throw new ArgumentException(string.Format(ExceptionMessages.InvalidTeamName, teamName));
    }

    team.RemovePlayer(playerName);
}

static void PrintRating(string teamName, List<Team> teamList)
{
    Team team = teamList.FirstOrDefault(n => n.Name == teamName);

    if (team == null)
    {
        throw new ArgumentException(string.Format(ExceptionMessages.InvalidTeamName, teamName));
    }

    Console.WriteLine(team);
}




