namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        private const int InitCapacity = 20;

        public WeightliftingGym(string name) : base(name, InitCapacity)
        {
        }
    }
}