using System;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        protected override Func<IDriver, bool> GetCurrentName(string name)
        {
            return x => x.Name == name;
        }
    }
}