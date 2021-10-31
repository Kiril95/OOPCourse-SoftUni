using System;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == nameof(Vegetable) || food.GetType().Name == nameof(Meat))
            {
                double gainWeight = food.Quantity * 0.30;
                Weight += gainWeight;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}