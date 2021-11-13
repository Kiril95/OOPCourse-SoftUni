using System;
using NUnit.Framework;
using Skeleton.Models;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int AxeAttack = 10;
        private const int AxeDurability = 10;
        private const int DummyHp = 20;
        private const int DummyExp = 50;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SettingUpSubjects()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHp, DummyExp);
        }

        [Test]
        public void DummyLoosesHealthWhenAttacked()
        {
            axe.Attack(dummy);
            Assert.AreEqual(10, dummy.Health, "Dummy doesn't loose health when attacked!");
        }

        [Test]
        public void DummyThrowsExceptionIfDead()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            var error = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(dummy));
            Assert.AreEqual("Dummy is dead.", error.Message);
        }

        [Test]
        public void DummyGivesExperienceIfDead()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.AreEqual(DummyExp, dummy.GiveExperience(), "Dead Dummy cannot give experience!");
        }

        [Test]
        public void DummyDoesNotGiveExperienceIfAlive()
        {
            var error = Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());
            Assert.AreEqual(error.Message, "Target is not dead.");
        }
    }
}
