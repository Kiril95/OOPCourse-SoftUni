using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;
        private const double ModifierPerGram = 2;

        private readonly Dictionary<string, double> DoughModifiers = new Dictionary<string, double>
        {
            { "white", 1.5 },
            { "wholegrain", 1.0 },
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1.0 }
        };

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => flourType;

            private set
            {
                if (!DoughModifiers.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;

            private set
            {
                if (!DoughModifiers.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => weight;
            
            private set
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                }

                weight = value;
            }
        }
        public double CalculateDoughCalories()
        {
            var flour = DoughModifiers.Where(x => x.Key == FlourType).Select(x => x.Value).FirstOrDefault();
            var technique = DoughModifiers.Where(x => x.Key == BakingTechnique).Select(x => x.Value).FirstOrDefault();

            return ModifierPerGram * this.Weight * flour * technique;
        }
    }
}
