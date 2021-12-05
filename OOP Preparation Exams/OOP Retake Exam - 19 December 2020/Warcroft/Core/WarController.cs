using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> heroes;
        private List<Item> items;

		public WarController()
        {
            heroes = new List<Character>();
            items = new List<Item>();
        }

		public string JoinParty(string[] args)
        {
            string charType = args[0];
            string heroName = args[1];
            Character hero;

            if (charType == nameof(Warrior))
            {
                hero = new Warrior(heroName);
            }
            else if (charType == nameof(Priest))
            {
                hero = new Priest(heroName);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, charType));
            }

            heroes.Add(hero);
            return string.Format(SuccessMessages.JoinParty, heroName);
        }

		public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item;

            if (itemName == nameof(FirePotion))
            {
                item = new FirePotion();
            }
            else if (itemName == nameof(HealthPotion))
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

            items.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

		public string PickUpItem(string[] args)
        {
            string heroName = args[0];
            Item targetItem = items.LastOrDefault();
            var targetHero = heroes.FirstOrDefault(x => x.Name == heroName);

            if (targetHero is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, heroName));
            }

            if (targetItem is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));
            }

            targetHero.Bag.AddItem(targetItem);
            items.Remove(targetItem);
            return string.Format(SuccessMessages.PickUpItem, heroName, targetItem.GetType().Name);
        }

        public string UseItem(string[] args)
		{
            string heroName = args[0];
            string itemName = args[1];
            var targetHero = heroes.FirstOrDefault(x => x.Name == heroName);
            var targetItem = targetHero?.Bag.GetItem(itemName);

            if (targetHero is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, heroName));
            }

            targetHero.UseItem(targetItem);
            return string.Format(SuccessMessages.UsedItem, heroName, itemName);
        }

        public string GetStats()
		{
            StringBuilder sb = new StringBuilder();
            var ordered = heroes
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health);

            foreach (var hero in ordered)
            {
                string status = hero.IsAlive ? "Alive" : "Dead";

                sb.AppendLine(string.Format(SuccessMessages.CharacterStats, 
                    hero.Name, hero.Health, hero.BaseHealth,
                    hero.Armor, hero.BaseArmor, status));
            }

            return sb.ToString().TrimEnd();
        }

		public string Attack(string[] args)
        {
            //POSSIBLE ERRORS
            string attackerName = args[0];
            string receiverName = args[1];
            var targetAttacker = heroes.FirstOrDefault(x => x.Name == attackerName);
            var targetReceiver = heroes.FirstOrDefault(x => x.Name == receiverName);

            if (targetAttacker is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (targetReceiver is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (heroes.First(x => x.Name == attackerName).GetType().Name != nameof(Warrior))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            Warrior warrior = (Warrior)heroes.First(x => x.Name == attackerName);
            warrior.Attack(targetReceiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter,
                warrior.Name, targetReceiver.Name, warrior.AbilityPoints,
                targetReceiver.Name, targetReceiver.Health, targetReceiver.BaseHealth,
                targetReceiver.Armor, targetReceiver.BaseArmor));

            if (!targetReceiver.IsAlive)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, targetReceiver.Name));
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
		{
            //POSSIBLE ERRORS
            string healerName = args[0];
            string receiverName = args[1];
            var targetHealer = heroes.FirstOrDefault(x => x.Name == healerName);
            var targetReceiver = heroes.FirstOrDefault(x => x.Name == receiverName);

            if (targetHealer is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            if (targetReceiver is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (heroes.First(x => x.Name == healerName).GetType().Name != nameof(Priest))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            IHealer healer = heroes.First(x => x.Name == healerName) as IHealer;
            healer?.Heal(targetReceiver);

            return string.Format(SuccessMessages.HealCharacter, 
                targetHealer.Name, targetReceiver.Name, targetHealer.AbilityPoints, 
                targetReceiver.Name, targetReceiver.Health);
        }
	}
}