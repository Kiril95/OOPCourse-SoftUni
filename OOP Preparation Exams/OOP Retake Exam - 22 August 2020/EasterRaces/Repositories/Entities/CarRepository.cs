using EasterRaces.Models.Cars.Contracts;
using System;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        protected override Func<ICar, bool> GetCurrentName(string name)
        {
            return x => x.Model == name;
        }
    }
}