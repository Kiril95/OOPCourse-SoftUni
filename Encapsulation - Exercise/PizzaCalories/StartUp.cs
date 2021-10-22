using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] tokens = Console.ReadLine().Split();
                Pizza pizza = new Pizza(tokens[1]);
                tokens = Console.ReadLine().Split();
                pizza.Dough = new Dough(tokens[1].ToLower(), tokens[2].ToLower(), int.Parse(tokens[3]));

                string command = Console.ReadLine();
                while (command != "END")
                {
                    tokens = command.Split();
                    pizza.AddTopping(new Topping(tokens[1].ToLower(), int.Parse(tokens[2])));
                    command = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
