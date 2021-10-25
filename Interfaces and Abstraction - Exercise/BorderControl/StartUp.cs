using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> allEntities = new List<IIdentifiable>();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] operations = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (operations.Length == 2)
                {
                    Robot terminator = new Robot(operations[0], operations[1]);
                    allEntities.Add(terminator);
                }
                else if (operations.Length == 3)
                {
                    Citizen guy = new Citizen(operations[0], int.Parse(operations[1]), operations[2]);
                    allEntities.Add(guy);
                }

                command = Console.ReadLine();
            }
            string numbers = Console.ReadLine();

            List<string> detained = allEntities
                .Where(x => x.Id.EndsWith(numbers))
                .Select(x => x.Id)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, detained));
        }
    }
}
