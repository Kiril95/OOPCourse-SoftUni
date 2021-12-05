using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters.Contracts
{
    public class Warrior : Character, IAttacker
    {
        private const double InitialHealth = 100;
        private const double InitialArmor = 50;
        private const double InitialAbilityPoints = 40;

        public Warrior(string name) 
            : base(name, InitialHealth, InitialArmor, InitialAbilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            if (character.IsAlive)
            {
                if (this == character)
                {
                    throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
                }

                character.TakeDamage(this.AbilityPoints);
            }
        }
    }
}