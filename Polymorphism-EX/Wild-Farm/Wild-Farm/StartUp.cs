using Wild_Farm.Core.Interfaces;
using Wild_Farm.Factories.Interfaces;
using Wild_Farm.Factories;
using Wild_Farm.IO.Interfaces;
using Wild_Farm.IO;
using WildFarm.Core;


IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IAnimalFactory animalFactory = new AnimalFactory();
IFoodFactory foodFactory = new FoodFactory();

IEngine engine = new Engine(reader, writer, animalFactory, foodFactory);

engine.Run();