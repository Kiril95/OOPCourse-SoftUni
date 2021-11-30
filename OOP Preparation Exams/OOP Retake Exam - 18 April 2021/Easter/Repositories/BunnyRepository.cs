using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> rabbits = new List<IBunny>();
        public IReadOnlyCollection<IBunny> Models => rabbits.AsReadOnly();
        
        public void Add(IBunny model)
        {
            this.rabbits.Add(model);
        }

        public bool Remove(IBunny model)
        {
            return rabbits.Remove(model);
        }

        public IBunny FindByName(string name)
        {
            return rabbits.FirstOrDefault(x => x.Name == name);
        }
    }
}