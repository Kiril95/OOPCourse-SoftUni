using System;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts = new AstronautRepository();
        private PlanetRepository planets = new PlanetRepository();
        private Mission mission = new Mission();
        private int exploredPlanets;

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astro;

            if (type == nameof(Biologist))
            {
                astro = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astro = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astro = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astronauts.Add(astro);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            var target = astronauts.FindByName(astronautName);

            if (target == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(target);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            ICollection<IAstronaut> suitableAstronauts = astronauts.Models.Where(x => x.Oxygen > 60).ToList();
            var planetToExplore = planets.FindByName(planetName);

            if (!suitableAstronauts.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            mission.Explore(planetToExplore, suitableAstronauts);
            exploredPlanets++;
            int deadAstronauts = 0;
            foreach (var astro in suitableAstronauts)
            {
                if (!astro.CanBreath)
                {
                    deadAstronauts++;
                }
            }
            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astro in astronauts.Models)
            {
                sb.AppendLine($"Name: {astro.Name}");
                sb.AppendLine($"Oxygen: {astro.Oxygen}");
                string bagContents = astro.Bag.Items.Any() ? string.Join(", ", astro.Bag.Items) : "none";
                sb.AppendLine($"Bag items: {bagContents}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}