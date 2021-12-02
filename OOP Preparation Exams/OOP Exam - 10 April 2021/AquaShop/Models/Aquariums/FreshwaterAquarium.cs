namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int InitialCapacity = 50;

        public FreshwaterAquarium(string name) : base(name, InitialCapacity)
        {
        }
    }
}