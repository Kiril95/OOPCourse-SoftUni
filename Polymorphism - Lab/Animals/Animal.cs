namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;

        public Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }
        public string Name { get; private set; }
        public string FavouriteFood { get; private set; }

        public virtual string ExplainSelf()
        {
            return null;
        }

        public override string ToString()
        {
            return $"I am {this.Name} and my favourite food is {this.FavouriteFood}";
        }
    }
}