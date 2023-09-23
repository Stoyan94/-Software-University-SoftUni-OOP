using Pizza_Calories;
using System;


string input;

while ((input = Console.ReadLine()) !="END")
{
    string[] splitInput = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);

	try
	{
		Dough dough = new Dough(splitInput[1], splitInput[2], int.Parse(splitInput[3]));

        Console.WriteLine(dough);
    }
	catch (ArgumentException ex)
	{

        Console.WriteLine(ex);
    }
}