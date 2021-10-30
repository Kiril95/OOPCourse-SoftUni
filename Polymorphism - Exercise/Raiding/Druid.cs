using System;

namespace Raiding
{
    public class Druid : BaseHero
    {
        private const int DefPower = 80;
        public Druid(string name) : base(name, DefPower)
        {
        }

        public override void CastAbility()
        {
            Console.WriteLine($"{GetType().Name} - {Name} healed for {Power}");
        }
    }
}