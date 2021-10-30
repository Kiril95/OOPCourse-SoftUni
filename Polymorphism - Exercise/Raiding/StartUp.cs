using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int neededHeroes = int.Parse(Console.ReadLine());
            List<BaseHero> raid = new List<BaseHero>();

            while (raid.Count != neededHeroes)
            {
                string name = Console.ReadLine();
                string heroClass = Console.ReadLine();

                if (heroClass == nameof(Paladin))
                {
                    raid.Add(new Paladin(name));
                }

                else if (heroClass == nameof(Druid))
                {
                    raid.Add(new Druid(name));
                }

                else if (heroClass == nameof(Rogue))
                {
                    raid.Add(new Rogue(name));
                }

                else if (heroClass == nameof(Warrior))
                {
                    raid.Add(new Warrior(name));
                }

                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            int bossHP = int.Parse(Console.ReadLine());

            foreach (var hero in raid)
            {
                hero.CastAbility();
            }

            int maxDmg = raid.Sum(x => x.Power);
            Console.WriteLine(maxDmg >= bossHP ? "Victory!" : "Defeat...");

        }
    }
}
