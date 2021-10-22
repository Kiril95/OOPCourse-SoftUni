using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double grams;
        private const double ModifierPerGram = 2;

        private readonly Dictionary<string, double> ToppingModifiers = new Dictionary<string, double>
        {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 }
        };

        public Topping(string type, double grams)
        {
            this.Type = type;
            this.Grams = grams;
        }
        public double Grams
        {
            get => grams;
            
            private set
            {
                if (value < 1 || value > 50)
                {
                    var fixedCasing = this.Type[0].ToString().ToUpper() + this.Type.Substring(1);
                    throw new ArgumentException($"{fixedCasing} weight should be in the range [1..50].");
                }
                grams = value;
            }
        }

        public string Type
        {
            get => type; 
             
            private set
            {
                if (!ToppingModifiers.ContainsKey(value))
                {
                    var tempCasing = value[0].ToString().ToUpper() + value.Substring(1);
                    throw new ArgumentException($"Cannot place {tempCasing} on top of your pizza.");
                }

                type = value;
            }
        }
        public double CalculateToppingCalories()
        {
            var currentToppingModifier = ToppingModifiers.Where(x => x.Key == this.Type).Select(x => x.Value).FirstOrDefault();

            return ModifierPerGram * this.Grams * currentToppingModifier;
        }
    }
}
