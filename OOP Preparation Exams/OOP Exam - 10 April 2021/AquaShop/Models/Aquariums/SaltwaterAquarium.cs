namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int InitialCapacity = 25;

        public SaltwaterAquarium(string name) : base(name, InitialCapacity)
        {
        }
    }
}