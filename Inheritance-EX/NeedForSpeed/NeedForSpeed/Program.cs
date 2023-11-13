using System;
using NeedForSpeed;
using NeedForSpeed.Models;
using NeedForSpeed.Models.Cars;
using NeedForSpeed.Models.Motorcycles;

Vehicle car = new Car(35,120);
Vehicle morcycle = new RaceMotorcycle(15,115);
Vehicle sportCar = new SportCar(70,750);

sportCar.Drive(100);
morcycle.Drive(15);
car.Drive(85);

Console.WriteLine(car);
Console.WriteLine(morcycle);
Console.WriteLine(sportCar);
