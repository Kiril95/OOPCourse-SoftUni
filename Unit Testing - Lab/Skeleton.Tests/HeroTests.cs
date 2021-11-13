using System;
using Moq;
using NUnit.Framework;
using Skeleton.Interfaces;
using Skeleton.Models;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        private Hero player;
        private int startExp;
        private IWeapon fakeAxe = new Axe(10, 10);
        private ITarget fakeDummy = new Dummy(20, 10);
        
        [SetUp]
        public void SettingUpSubjects()
        {
            player = new Hero("Toshko", fakeAxe);
            startExp = 0;
        }
         
        [Test]
        public void HeroGainsExperienceWhenTargetDies()
        {
            player.Attack(fakeDummy);
            Assert.AreEqual(startExp + 10, fakeDummy.GiveExperience(), "Hero does not gain experience!");
        }

        [Test]
        public void HeroDoesNotGainExperienceWhenTargetIsAlive()
        {
            player.Attack(fakeDummy);
            Assert.AreEqual(startExp, player.Experience, "Target is still alive!");
        }


        readonly Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        readonly Mock<ITarget> fakeTarget = new Mock<ITarget>();

        [Test]
        public void HeroGainsExperienceWhenTargetDies_Mock()
        {
            fakeTarget.Setup(t => t.IsDead()).Returns(true);
            fakeTarget.Setup(t => t.GiveExperience()).Returns(fakeDummy.Experience);

            player = new Hero("Mr.Mock", fakeWeapon.Object);
            player.Attack(fakeTarget.Object);

            Assert.AreEqual(startExp + 10, player.Experience, "Hero does not gain experience!");
        }

        [Test]
        public void HeroDoesNotGainExperienceWhenTargetIsAlive_Mock()
        {
            fakeTarget.Setup(t => t.IsDead()).Returns(false);
            fakeTarget.Setup(t => t.GiveExperience()).Callback(() => throw new InvalidOperationException("Dummy is dead."));

            player = new Hero("Mr.Mock", fakeWeapon.Object);
            player.Attack(fakeTarget.Object);

            Assert.AreEqual(startExp, player.Experience, "Target is still alive!");
        }
    }
}
