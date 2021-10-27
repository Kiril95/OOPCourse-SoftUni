using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ILieutenantGeneral
    {
        IList<Private> Privates { get; }
    }
}
