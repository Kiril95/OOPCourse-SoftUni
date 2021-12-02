using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;
    [TestFixture]
    public class AquariumsTests
    {
        private Fish fish;
        private Aquarium aquarium;

        [SetUp]
        public void Setup()
        {
            fish = new Fish("Nemo");
            aquarium = new Aquarium("Ocean", 3);
            aquarium.Add(fish);
        }

        [Test]
        public void VerifyConstructor()
        {
            Assert.IsNotNull(fish, "The constructor is broken!");
            Assert.IsNotNull(aquarium, "The constructor is broken!");
        }

        [Test]
        public void VerifyNameProperty()
        {
            Assert.AreEqual("Ocean", aquarium.Name, "Property isn't working right!");
        }

        [Test]
        public void NamePropertyThrowsExceptionIfNullEmptyOrWhitespace()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 1));
            Assert.Throws<ArgumentNullException>(() => new Aquarium(string.Empty, 2));
        }

        [Test]
        public void VerifyAvailableProperty()
        {
            Assert.AreEqual(true, fish.Available, "Property isn't working right!");
        }

        [Test]
        public void VerifyCapacityProperty()
        {
            Assert.AreEqual(3, aquarium.Capacity, "Property isn't working right!");
        }

        [Test]
        public void CapacityPropertyThrowsExceptionIfValueIsNegative()
        {
            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium("Arrr", -1));
        }

        [Test]
        public void VerifyAquariumCollection()
        {
            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void VerifyAddMethod()
        {
            Fish temp = new Fish("Momo");
            aquarium.Add(temp);

            Assert.AreEqual(2, aquarium.Count);
        }

        [Test]
        public void AddMethodThrowsExceptionWhenCollectionReachesAllowetCapacity()
        {
            aquarium.Add(new Fish("Gogo"));
            aquarium.Add(new Fish("Bogo"));

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Nono")));
        }

        [Test]
        public void VerifyRemoveFishMethod()
        {
            aquarium.RemoveFish(fish.Name);
            Assert.AreEqual("Nemo", fish.Name);
        }

        [Test]
        public void RemoveFishMethodThrowsExceptionWhenEntityIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(null));
        }

        [Test]
        public void VerifySellFishMethod()
        {
            Fish tempFish = aquarium.SellFish(fish.Name);
            Assert.AreEqual(fish, tempFish);
            Assert.AreEqual(false, fish.Available);
        }

        [Test]
        public void SellFishFishMethodThrowsExceptionWhenEntityIsNull()
        {
            fish = null;
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(fish?.Name));
        }

        [Test]
        public void VerifyReportMethod()
        {
            string expectedMessage = $"Fish available at {aquarium.Name}: {fish.Name}";

            Assert.AreEqual(expectedMessage, aquarium.Report());
        }
    }
}
