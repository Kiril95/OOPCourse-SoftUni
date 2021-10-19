using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main()
        {
            //This one project assembles four separate exercises from the Encapsulation lecture.
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                try
                {
                    var cmdArgs = Console.ReadLine().Split();

                    var firstName = cmdArgs[0];
                    var lastName = cmdArgs[1];
                    var age = int.Parse(cmdArgs[2]);
                    var salary = decimal.Parse(cmdArgs[3]);

                    var person = new Person(firstName, lastName, age, salary);

                    persons.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Team team = new Team("SoftUni");

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }
            Console.WriteLine(team);
        }
    }
}
