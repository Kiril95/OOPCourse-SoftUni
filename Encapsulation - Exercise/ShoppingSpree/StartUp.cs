using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] clients = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] groceries = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                for (int i = 0; i < clients.Length; i++)
                {
                    string currentGuy = clients[i];
                    string[] subSplit = currentGuy.Split("=", StringSplitOptions.RemoveEmptyEntries);

                    Person guy = new Person(subSplit[0], int.Parse(subSplit[1]));
                    people.Add(guy);
                }

                for (int i = 0; i < groceries.Length; i++)
                {
                    string currentProduct = groceries[i];
                    string[] subSplit = currentProduct.Split("=", StringSplitOptions.RemoveEmptyEntries);

                    Product product = new Product(subSplit[0], int.Parse(subSplit[1]));
                    products.Add(product);

                }
                string command = Console.ReadLine();
                while (command != "END")
                {
                    try
                    {
                        string[] operations = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        string name = operations[0];
                        string product = (operations[1]);
                        if (people.Any(x => x.Name == name) && products.Any(x => x.Name == product))
                        {
                            var currentPerson = people.Find(x => x.Name == name);
                            var currentProduct = products.Find(x => x.Name == product);

                            currentPerson.Buy(currentProduct);
                        }
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }

                    command = Console.ReadLine();
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }

        }
    }
}
