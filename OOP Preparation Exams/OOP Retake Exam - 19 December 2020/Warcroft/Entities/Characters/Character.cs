using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                this.name = value;
            }
        }
        public double BaseHealth { get; private set; }
        public double Health
        {
            get => this.health;

            set
            {
                if (value > BaseHealth)
                {
                    health = BaseHealth;
                }
                else if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    this.health = value;
                }
            }
        }
        public double BaseArmor { get; private set; }
        public double Armor
        {
            get => this.armor;

            private set
            {
                if (value > BaseArmor)
                {
                    armor = BaseArmor;
                }
                else if (value < 0)
                {
                    armor = 0;
                }
                else
                {
                    this.armor = value;
                }
            }
        }
        public double AbilityPoints { get; private set; }
        public IBag Bag { get; private set; }
        public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();
            if (Armor >= hitPoints)
            {
                Armor -= hitPoints;
            }
            else
            {
                Armor -= hitPoints;
                Health -= Math.Abs(Armor);

                this.Armor = 0;

                if (Health <= 0)
                {
                    this.Health = 0;
                    IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);

            if (this.Health <= 0)
            {
                Health = 0;
                IsAlive = false;
            }
        }
    }
}