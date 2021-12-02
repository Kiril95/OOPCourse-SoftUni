using System.Collections.Generic;
using System.Linq;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorations = new List<IDecoration>();
        public IReadOnlyCollection<IDecoration> Models => decorations.AsReadOnly();

        public void Add(IDecoration model)
        {
            this.decorations.Add(model);
        }

        public bool Remove(IDecoration model)
        {
            return this.decorations.Remove(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.decorations.FirstOrDefault(x => x.GetType().Name == type);
        }
    }
}