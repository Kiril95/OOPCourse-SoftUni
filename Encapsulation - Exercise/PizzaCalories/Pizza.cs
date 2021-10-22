using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private readonly IList<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }
        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1 ||value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        //private IList<Topping> Toppings => new List<Topping>();
        public Dough Dough
        {
            set => dough = value;
        }
        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }
        public double TotalCalories()
        {
            var totalCalories = this.dough.CalculateDoughCalories() + this.toppings.Sum(x => x.CalculateToppingCalories());

            return totalCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories():f2} Calories.";
        }

    }
}
