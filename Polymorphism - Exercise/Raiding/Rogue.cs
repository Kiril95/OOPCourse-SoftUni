using System;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int DefPower = 80;
        public Rogue(string name) : base(name, DefPower)
        {
        }

        public override void CastAbility()
        {
            Console.WriteLine($"{GetType().Name} - {Name} hit for {Power} damage");
        }
    }
}