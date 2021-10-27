using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] operations = command.Split();
                string type = operations[0];

                if (type == nameof(Private))
                {
                    string id = operations[1];
                    string firstName = operations[2];
                    string lastName = operations[3];
                    decimal salary = decimal.Parse(operations[4]);

                    soldiers.Add(new Private(id, firstName, lastName, salary));
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    string id = operations[1];
                    string firstName = operations[2];
                    string lastName = operations[3];
                    decimal salary = decimal.Parse(operations[4]);

                    List<Private> privates = new List<Private>();

                    for (int i = 5; i < operations.Length; i++)
                    {
                        Private check = (Private)soldiers.FirstOrDefault(x => x.Id == operations[i]);

                        privates.Add(check);
                    }

                    soldiers.Add(new LieutenantGeneral(id, firstName, lastName, salary, privates));
                }
                else if (type == nameof(Engineer))
                {
                    try
                    {
                        string id = operations[1];
                        string firstName = operations[2];
                        string lastName = operations[3];
                        decimal salary = decimal.Parse(operations[4]);
                        string corp = operations[5];

                        List<Repair> repairs = new List<Repair>();

                        for (int i = 6; i < operations.Length; i += 2)
                        {
                            repairs.Add(new Repair(operations[i], int.Parse(operations[i + 1])));
                        }

                        soldiers.Add(new Engineer(id, firstName, lastName, salary, corp, repairs));
                    }
                    catch (ArgumentException)
                    {
                    }
                }
                else if (type == nameof(Commando))
                {
                    string id = operations[1];
                    string firstName = operations[2];
                    string lastName = operations[3];
                    decimal salary = decimal.Parse(operations[4]);
                    string corp = operations[5];

                    List<Mission> missions = new List<Mission>();

                    for (int i = 6; i < operations.Length; i += 2)
                    {
                        try
                        {
                            missions.Add(new Mission(operations[i], operations[i + 1]));
                        }
                        catch (ArgumentException)
                        {
                        }
                    }

                    soldiers.Add(new Commando(id, firstName, lastName, salary, corp, missions));
                }
                else if (type == nameof(Spy))
                {
                    string id = operations[1];
                    string firstName = operations[2];
                    string lastName = operations[3];
                    int codeNumber = int.Parse(operations[4]);

                    soldiers.Add(new Spy(id, firstName, lastName, codeNumber));
                }

                command = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
