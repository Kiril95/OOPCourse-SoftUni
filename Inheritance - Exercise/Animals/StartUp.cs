using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animal = Console.ReadLine();
            List<Animal> animals = new List<Animal>();
            
            while (animal != "Beast!")
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Animal currentAnimal = null;
                try
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string gender = info[2];
                    
                    if (animal == "Dog")
                    {
                        currentAnimal = new Dog(name, age, gender);
                    }
                    else if (animal == "Cat")
                    {
                        currentAnimal = new Cat(name, age, gender);
                    }
                    else if (animal == "Frog")
                    {
                        currentAnimal = new Frog(name, age, gender);
                    }
                    else if (animal == "Tomcat")
                    {
                        currentAnimal = new Tomcat(name, age);
                    }
                    else if (animal == "Kitten")
                    {
                        currentAnimal = new Kitten(name, age);
                    }

                    animals.Add(currentAnimal);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animal = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, animals));

        }
    }
}
