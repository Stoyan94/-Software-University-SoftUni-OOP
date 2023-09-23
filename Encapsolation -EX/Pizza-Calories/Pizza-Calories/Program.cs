using Pizza_Calories;
using System;
using System.Linq;



string doughType = "White";
string doughTech = "Chewy";
int doughGrams = 100;

string toppingName = "Veggies";
int toppingGrams = 10;

Dough dough = new Dough(doughType, doughTech, doughGrams);

Topping topping = new Topping(toppingName, toppingGrams);

Pizza pizza = new Pizza("  ",dough, topping);
