namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double InitWeight = 10000;
        private const decimal InitPrice = 80;

        public Kettlebell() : base(InitWeight, InitPrice)
        {
        }
    }
}