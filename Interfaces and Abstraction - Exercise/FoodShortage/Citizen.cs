using System;

namespace BirthdayCelebrations
{
    public class Citizen : IBuyer, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Birthdate { get; private set; }
        public int Food { get; private set; } = 0;

        public void BuyFood()
        {
            this.Food += 10;
        }

    }
}
