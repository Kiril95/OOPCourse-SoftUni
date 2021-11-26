using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> astronauts = new List<IAstronaut>();
        public IReadOnlyCollection<IAstronaut> Models => astronauts.AsReadOnly();

        public void Add(IAstronaut model)
        {
            this.astronauts.Add(model);
        }

        public bool Remove(IAstronaut model)
        {
            return astronauts.Remove(model);
        }

        public IAstronaut FindByName(string name)
        {
            return astronauts.FirstOrDefault(x => x.Name == name);
        }
    }
}