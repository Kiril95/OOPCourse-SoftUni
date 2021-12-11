namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int InitCapacity = 15;

        public BoxingGym(string name) : base(name, InitCapacity)
        {
        }
    }
}