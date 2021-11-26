using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace HeroRepository.Tests
{
    [TestFixture]
    public class HeroRepositoryTests
    {
        private Hero player;
        private List<Hero> heroes;
        private HeroRepository repo;

        [SetUp]
        public void Setup()
        {
            player = new Hero("Kircho", 80);
            repo = new HeroRepository();
            repo.Create(player);
        }

        [Test]
        public void VerifyConstructor()
        {
            Assert.IsNotNull(player, "The constructor is broken!");
            Assert.IsNotNull(repo, "The constructor is broken!");
        }

        [Test]
        public void VerifyNameProperty()
        {
            Assert.AreEqual("Kircho", player.Name, "Property isn't working right!");
        }

        [Test]
        public void VerifyLevelProperty()
        {
            Assert.AreEqual(80, player.Level, "Property isn't working right!");
        }

        [Test]
        public void VerifyCreateMethod()
        {
            Hero temp = new Hero("Pepe", 5);
            string expMess = $"Successfully added hero {temp.Name} with level {temp.Level}";

            Assert.AreEqual(expMess, repo.Create(temp));
        }

        [Test]
        public void CreateMethodThrowsExceptionWhenHeroEntityIsNull()
        {
            player = null;
            Assert.Throws<ArgumentNullException>(() => repo.Create(player));
        }

        [Test]
        public void CreateMethodThrowsExceptionWhenGivenHeroExists()
        {
            Assert.Throws<InvalidOperationException>(() => repo.Create(player));
        }

        [Test]
        public void VerifyRemoveMethod()
        {
            Hero temp = new Hero("Pepe", 5);
            repo.Create(temp);
            Assert.AreEqual(true, repo.Remove(temp.Name));
        }

        [Test]
        public void RemoveMethodThrowsExceptionIfNullEmptyOrWhitespace()
        {
            Hero temp1 = new Hero(null, 5);
            Hero temp2 = new Hero(" ", 5);
            Hero temp3 = new Hero("", 5);
            repo.Create(temp1);
            repo.Create(temp2);
            repo.Create(temp3);
            Assert.Throws<ArgumentNullException>(() => repo.Remove(temp1.Name));
            Assert.Throws<ArgumentNullException>(() => repo.Remove(temp2.Name));
            Assert.Throws<ArgumentNullException>(() => repo.Remove(temp3.Name));
        }

        [Test]
        public void VerifyGetHeroWithHighestLevelMethod()
        {
            Hero temp = new Hero("Pepe", 5);
            repo.Create(temp);
            var target = repo.GetHeroWithHighestLevel();

            Assert.AreEqual(player, target);
        }

        [Test]
        public void VerifyGetHeroMethod()
        {
            var target = repo.GetHero(player.Name);

            Assert.AreEqual(player, target);
        }

        [Test]
        public void VerifyReadOnlyCollection()
        {
            var expectedCollection = repo.Heroes;
            Assert.True(expectedCollection is IReadOnlyCollection<Hero>);
        }

    }
}