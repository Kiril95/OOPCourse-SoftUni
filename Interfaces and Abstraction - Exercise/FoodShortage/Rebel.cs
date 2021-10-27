using BirthdayCelebrations;

namespace FoodShortage
{
    public class Rebel : IBuyer
    {
        private string group;
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; private set; }
        public int Food { get; private set; } = 0;
        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
