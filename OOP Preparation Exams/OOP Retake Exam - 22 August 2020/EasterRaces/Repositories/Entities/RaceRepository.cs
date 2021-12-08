using System;
using EasterRaces.Models.Races.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : Repository<IRace>
    {
        protected override Func<IRace, bool> GetCurrentName(string name)
        {
            return x => x.Name == name;
        }
    }
}