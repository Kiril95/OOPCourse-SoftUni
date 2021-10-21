using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private IList<Product> bag;
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            this.bag = new List<Product>();
        }
        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public void Buy(Product product)
        {
            if (Money >= product.Cost)
            {
                Money -= product.Cost;
                bag.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                throw new ArgumentException($"{Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            return $"{Name} - {(bag.Count > 0 ? string.Join(", ", bag) : "Nothing bought")}";
        }
            
    }
}
