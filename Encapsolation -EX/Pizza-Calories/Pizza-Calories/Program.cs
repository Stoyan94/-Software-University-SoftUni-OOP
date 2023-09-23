using Pizza_Calories;
using System;


string input;

while ((input = Console.ReadLine()) !="END")
{
    string[] splitInput = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);

	try
	{
        if (splitInput[0] == "Dough")
        {		
            Dough dough = new Dough(splitInput[1], splitInput[2], int.Parse(splitInput[3]));
            Console.WriteLine(dough);
        }              
        else if (splitInput[0] == "Topping")
        {
            Topping topping = new Topping(splitInput[1], int.Parse(splitInput[2]));
            Console.WriteLine(topping);
        }
        else if (true)
        {

        }
        

		
    }
	catch (ArgumentException ex)
	{

        Console.WriteLine(ex);
    }
}