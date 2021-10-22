using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] operations = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string command = operations[0];
                try
                {
                    if (command == "Team")
                    {
                        teams.Add(new Team(operations[1]));
                    }

                    else if (command == "Add")
                    {
                        if (!teams.Any(x => x.Name == operations[1]))
                        {
                            throw new ArgumentException($"Team {operations[1]} does not exist.");
                        }
                        else
                        {
                            Stats stats = new Stats(int.Parse(operations[3]), int.Parse(operations[4]), int.Parse(operations[5]), int.Parse(operations[6]), int.Parse(operations[7]));
                            Team currentTeam = teams.FirstOrDefault(x => x.Name == operations[1]);
                            currentTeam.AddPlayer(new Player(operations[2], stats));
                        }
                    }

                    else if (command == "Remove")
                    {
                        Team currentTeam = teams.First(x => x.Name == operations[1]);
                        currentTeam.RemovePlayer(operations[2]);
                    }

                    else if (command == "Rating")
                    {
                        if (!teams.Any(x => x.Name == operations[1]))
                        {
                            throw new ArgumentException($"Team {operations[1]} does not exist.");
                        }

                        Team teamForPrint = teams.FirstOrDefault(x => x.Name == operations[1]);
                        Console.WriteLine(teamForPrint.ToString());
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

        }
    }
}
