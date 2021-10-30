using System;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        private const int DefPower = 100;
        public Paladin(string name) : base(name, DefPower)
        {
        }

        public override void CastAbility()
        {
            Console.WriteLine($"{GetType().Name} - {Name} healed for {Power}");
        }
    }
}