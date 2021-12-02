using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decor;
        private List<IFish> fishes;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decor = new List<IDecoration>();
            this.fishes = new List<IFish>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }
        public int Capacity { get; }
        public int Comfort => this.Decorations.Sum(x => x.Comfort);
        public ICollection<IDecoration> Decorations => this.decor;
        public ICollection<IFish> Fish => this.fishes;

        public void AddFish(IFish fish)
        {
            if (this.Capacity > this.fishes.Count)
            {
                Fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public bool RemoveFish(IFish fish)
        {
            return this.Fish.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} ({GetType().Name}):");
            sb.AppendLine($"Fish: {(Fish.Any() ? string.Join(", ", Fish.Select(x => x.Name)) : "none")}");
            sb.AppendLine($"Decorations: {Decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}