using System;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int DefPower = 100;
        public Warrior(string name) : base(name, DefPower)
        {
        }

        public override void CastAbility()
        {
            Console.WriteLine($"{GetType().Name} - {Name} hit for {Power} damage");
        }
    }
}