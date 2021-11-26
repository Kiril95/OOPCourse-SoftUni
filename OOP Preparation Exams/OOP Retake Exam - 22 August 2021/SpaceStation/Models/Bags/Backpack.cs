using System.Collections.Generic;
using SpaceStation.Models.Bags.Contracts;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private List<string> items = new List<string>();
        public ICollection<string> Items => this.items;
    }
}