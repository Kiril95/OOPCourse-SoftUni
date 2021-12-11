namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double InitWeight = 227;
        private const decimal InitPrice = 120;

        public BoxingGloves() : base(InitWeight, InitPrice)
        {
        }
    }
}