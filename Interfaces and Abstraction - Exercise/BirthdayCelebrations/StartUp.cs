using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> allEntities = new List<IBirthable>();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] operations = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = operations[0];

                if (type == nameof(Citizen))
                {
                    Citizen guy = new Citizen(operations[1], int.Parse(operations[2]), operations[3], operations[4]);
                    allEntities.Add(guy);
                }
                else if (type == nameof(Pet))
                {
                    Pet pet = new Pet(operations[1], operations[2]);
                    allEntities.Add(pet);
                }

                command = Console.ReadLine();
            }
            string year = Console.ReadLine();

            List<IBirthable> targets = allEntities
                .Where(x => x.Birthdate.EndsWith(year))
                .ToList();

            foreach (var date in targets)
            {
                Console.WriteLine(date.Birthdate);
            }

        }
    }
}
