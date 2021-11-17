using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace FightingArena.Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private IList<Warrior> warriors;
        private Warrior player;
        private Warrior enemy;

        [SetUp]
        public void Setup()
        {
            player = new Warrior("Caesar", 25, 100);
            enemy = new Warrior("Octavian", 15, 50);
            arena = new Arena();
            arena.Enroll(player);
            arena.Enroll(enemy);
            warriors = new List<Warrior>();
        }

        [Test]
        public void VerifyConstructor()
        {
            Assert.IsNotNull(arena, "The constructor is broken!");
        }

        [Test]
        public void VerifyWarriorCollection()
        {
            warriors = new List<Warrior>();
            warriors.Add(player);
            warriors.Add(enemy);
            Assert.AreEqual(warriors, arena.Warriors);
        }

        [Test]
        public void VerifyEnrollMethod()
        {
            int expected = 3;
            Warrior temp = new Warrior("Temp", 2, 3);
            arena.Enroll(temp);
            Assert.AreEqual(expected, arena.Count);
        }

        [Test]
        public void EnrollMethodThrowsExceptionWhenWarriorWithTheSameNameIsFound()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("Caesar", 5, 25)));
        }

        [Test]
        public void VerifyFightMethod()
        {
            string attacker = player.Name;
            string defender = enemy.Name;
            arena.Fight(attacker, defender);
            Assert.AreEqual(85, player.HP);
            Assert.AreEqual(25, enemy.HP);
        }

        [Test]
        public void FightMethodThrowsExceptionWhenAttackerEntityIsNull()
        {
            player = null;
            enemy = new Warrior("Goshy", 5, 6);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(player?.Name, enemy.Name));
        }

        [Test]
        public void FightMethodThrowsExceptionWhenDefenderEntityIsNull()
        {
            player = new Warrior("Peshy", 5, 6);
            enemy = null;
            Assert.Throws<InvalidOperationException>(() => arena.Fight(player.Name, enemy?.Name));
        }
    }
}
