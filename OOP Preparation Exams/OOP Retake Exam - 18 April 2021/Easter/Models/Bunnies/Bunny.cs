using System;
using System.Collections.Generic;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private List<IDye> dyes;

        protected Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.Dyes = new List<IDye>();
        }
        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidBunnyName);
                }

                this.name = value;
            }
        }
        public int Energy
        {
            get => this.energy;

            protected set
            {
                if (value < 0)
                {
                    energy = 0;
                }
                else
                {
                    this.energy = value;
                }
            }
        }
        public ICollection<IDye> Dyes { get; }

        public abstract void Work();

        public void AddDye(IDye dye)
        {
            this.Dyes.Add(dye);
        }
    }
}