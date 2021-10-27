using System;

namespace ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Country { get; private set; }

        public void GetName()
        {
            Console.WriteLine(this.Name);
        }

        void IResident.GetName()
        {
            Console.WriteLine($"Mr/Ms/Mrs {Name}");
        }
    }
}