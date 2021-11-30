using System;
using System.Linq;
using System.Text;
using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository rabbits = new BunnyRepository();
        private EggRepository eggs = new EggRepository();
        private Workshop workshop = new Workshop();
        private int colloredEggs = 0;

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;

            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            rabbits.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);
            var targetBunny = rabbits.FindByName(bunnyName);

            if (targetBunny is null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            targetBunny.Dyes.Add(dye);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            eggs.Add(egg);
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var targetEgg = eggs.FindByName(eggName);
            var chosenBunnies = rabbits.Models
                .Where(x => x.Energy >= 50)
                .OrderByDescending(x => x.Energy)
                .ToList();

            if (!chosenBunnies.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            foreach (var bunny in chosenBunnies)
            {
                if (bunny.Energy <= 0)
                {
                    chosenBunnies.Remove(bunny);
                }

                workshop.Color(targetEgg, bunny);
            }

            if (targetEgg.IsDone())
            {
                colloredEggs++;
                return string.Format(OutputMessages.EggIsDone, targetEgg.Name);
            }
            else
            {
                return string.Format(OutputMessages.EggIsNotDone, targetEgg.Name);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{colloredEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunn in rabbits.Models.Where(x => x.Energy > 0))
            {
                sb.AppendLine($"Name: {bunn.Name}");
                sb.AppendLine($"Energy: {bunn.Energy}");
                sb.AppendLine($"Dyes: {bunn.Dyes.Count(x => !x.IsFinished())} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}