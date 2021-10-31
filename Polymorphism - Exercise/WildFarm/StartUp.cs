using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Animal> farm = new List<Animal>();
            Food food = null;

            while (command != "End")
            {
                string[] animalInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] foodInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string animalType = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                if (animalType == nameof(Cat) || animalType == nameof(Tiger))
                {
                    string habitat = animalInfo[3];
                    string breed = animalInfo[4];
                    if (animalType == nameof(Cat))
                    {
                        farm.Add(new Cat(name, weight, habitat, breed));
                    }
                    else
                    {
                        farm.Add(new Tiger(name, weight, habitat, breed));
                    }
                }

                else if (animalType == nameof(Owl) || animalType == nameof(Hen))
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    if (animalType == nameof(Owl))
                    {
                        farm.Add(new Owl(name, weight, wingSize));
                    }
                    else
                    {
                        farm.Add(new Hen(name, weight, wingSize));
                    }
                }

                else if (animalType == nameof(Dog) || animalType == nameof(Mouse))
                {
                    string habitat = animalInfo[3];
                    if (animalType == nameof(Dog))
                    {
                        farm.Add(new Dog(name, weight, habitat));
                    }
                    else
                    {
                        farm.Add(new Mouse(name, weight, habitat));
                    }
                }

                string foodType = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);

                if (foodType == "Fruit")
                {
                    food = new Fruit(quantity);
                }
                else if (foodType == "Meat")
                {
                    food = new Meat(quantity);
                }
                else if (foodType == "Seeds")
                {
                    food = new Seeds(quantity);
                }
                else if (foodType == "Vegetable")
                {
                    food = new Vegetable(quantity);
                }

                try
                {
                    var currentAnimal = farm.Find(x => x.Name == name);
                    Console.WriteLine(currentAnimal.ProduceSound());
                    currentAnimal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                command = Console.ReadLine();
            }

            farm.ForEach(Console.WriteLine);
        }
    }
}
