using System;
using NUnit.Framework;
using Skeleton.Models;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int AxeAttack = 10;
        private const int AxeDurability = 10;
        private const int DummyHp = 10;
        private const int DummyExp = 10;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SettingUpSubjects()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHp, DummyExp);
        }

        [Test] 
        public void AxeLoosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);
            Assert.AreEqual(9, axe.DurabilityPoints, "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void AxeThrowsExceptionIfBroken()
        {
            axe = new Axe(AxeAttack, 0);

            var error = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(dummy));
            Assert.AreEqual("Axe is broken.", error.Message);
        }

        [Test]
        public void VerifyAxeAttackPoints()
        {
            Assert.AreEqual(10, axe.AttackPoints);
        }
    }
}