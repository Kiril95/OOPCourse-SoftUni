using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ICommando
    {
        IList<Mission> Missions { get; }
    }
}
