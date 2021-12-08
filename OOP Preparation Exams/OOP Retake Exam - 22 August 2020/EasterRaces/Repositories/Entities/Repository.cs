using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private List<T> models = new List<T>();

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.models.AsReadOnly();
        }

        public T GetByName(string name)
        {
            return this.models.FirstOrDefault(GetCurrentName(name));
        }

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }

        protected abstract Func<T, bool> GetCurrentName(string name);
    }
}