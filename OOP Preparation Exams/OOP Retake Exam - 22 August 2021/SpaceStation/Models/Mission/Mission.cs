using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts.Where(x => x.CanBreath))
            {
                while (planet.Items.Count > 0)
                {
                    if (!astronaut.CanBreath)
                    {
                        break;
                    }
                    string currentItem = planet.Items.First();
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(currentItem);
                    planet.Items.Remove(currentItem);
                }
            }
        }
    }
}