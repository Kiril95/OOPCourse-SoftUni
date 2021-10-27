using System;
using System.Collections.Generic;
using System.Linq;
using BirthdayCelebrations;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> allEntities = new List<IBuyer>();
            int times = int.Parse(Console.ReadLine());

            for (int i = 0; i < times; i++)
            {
                string[] operations = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = operations[0];
                if (!allEntities.Any(x => x.Name == name))
                {
                    if (operations.Length == 3)
                    {
                        Rebel rebel = new Rebel(operations[0], int.Parse(operations[1]), operations[2]);
                        allEntities.Add(rebel);
                    }
                    else if (operations.Length == 4)
                    {
                        Citizen guy = new Citizen(operations[0], int.Parse(operations[1]), operations[2], operations[3]);
                        allEntities.Add(guy);
                    }
                }
            }
            string client = Console.ReadLine();

            while (client != "End")
            {
                var currentBuyer = allEntities.FirstOrDefault(x => x.Name == client);
                if (currentBuyer != null)
                {
                    currentBuyer.BuyFood();
                }
                client = Console.ReadLine();
            }

            Console.WriteLine(allEntities.Sum(x => x.Food));

        }
    }
}
