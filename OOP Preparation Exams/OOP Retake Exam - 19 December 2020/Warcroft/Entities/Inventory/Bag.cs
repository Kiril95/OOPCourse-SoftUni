using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private const int DefaultCapacity = 100;
        private readonly List<Item> models = new List<Item>();

        protected Bag(int capacity)
        {
            Capacity = capacity;
        }

        public int Capacity { get; set; } = DefaultCapacity;
        public int Load => this.Items.Sum(x => x.Weight);
        public IReadOnlyCollection<Item> Items => this.models;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.models.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.models.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            var targetItem = this.models.FirstOrDefault(x => x.GetType().Name == name);
            if (targetItem is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.models.Remove(targetItem);
            return targetItem;
        }
    }
}