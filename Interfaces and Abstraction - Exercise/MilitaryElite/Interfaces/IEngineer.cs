using System.Collections.Generic;

namespace MilitaryElite
{
    public interface IEngineer
    {
        IList<Repair> Repairs { get; }
    }
}
