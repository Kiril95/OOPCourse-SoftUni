using Skeleton.Interfaces;

namespace Skeleton.Tests.Fakes
{
    public class FakeDummy : ITarget
    {
        public int Health => 0;
        public int Experience { get; }

        public int GiveExperience() => 20;

        public bool IsDead() => true;

        public void TakeAttack(int attackPoints)
        {
        }
    }
}