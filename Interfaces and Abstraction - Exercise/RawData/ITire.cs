using System.Collections.Generic;

namespace P01_RawData
{
    public interface ITire
    {
        KeyValuePair<double, int>[] Tires { get; set; }
    }
}