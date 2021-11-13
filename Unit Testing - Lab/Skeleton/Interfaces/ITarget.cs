namespace Skeleton.Interfaces
{
    public interface ITarget
    {
        int Health { get; }
        int Experience { get; }

        int GiveExperience();

        bool IsDead();

        void TakeAttack(int attackPoints);
    }
}