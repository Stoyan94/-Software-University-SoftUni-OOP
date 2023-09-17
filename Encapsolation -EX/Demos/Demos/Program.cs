using Demos;
using System;

Stadium stadium = new Stadium();

Hall hall = new Hall();

hall.AddRange(new List<string> {"stoqn", "julia" });
stadium.Remove("43");




public class Hall : Stadium
{
    public void AddRange(List<string> seats)
    {
        foreach (string seat in seats)
        {
            Add(seat);
        }
    }
}