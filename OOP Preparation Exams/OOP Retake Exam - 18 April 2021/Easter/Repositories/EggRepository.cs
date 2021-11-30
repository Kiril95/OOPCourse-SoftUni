using System.Collections.Generic;
using System.Linq;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> eggs = new List<IEgg>();
        public IReadOnlyCollection<IEgg> Models => eggs.AsReadOnly();

        public void Add(IEgg model)
        {
            this.eggs.Add(model);
        }

        public bool Remove(IEgg model)
        {
            return eggs.Remove(model);
        }

        public IEgg FindByName(string name)
        {
            return eggs.FirstOrDefault(x => x.Name == name);
        }
    }
}