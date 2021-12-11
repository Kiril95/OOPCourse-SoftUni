using System;
using NUnit.Framework;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private Athlete athlete;
        private Gym gym;

        [SetUp]
        public void Setup()
        {
            athlete = new Athlete("Kiril");
            gym = new Gym("Raptor", 2);
            gym.AddAthlete(athlete);
        }

        [Test]
        public void VerifyConstructor()
        {
            Assert.IsNotNull(athlete, "The constructor is broken!");
            Assert.IsNotNull(gym, "The constructor is broken!");
        }

        [Test]
        public void VerifyAthlete()
        {
            string name = "Kiril";
            Assert.AreEqual(name, athlete.FullName);
            Assert.AreEqual(false, athlete.IsInjured);
        }

        [Test]
        public void VerifyNameProperty()
        {
            Assert.AreEqual("Raptor", gym.Name, "Property isn't working right!");
        }

        [Test]
        public void NamePropertyThrowsExceptionIfNullEmptyOrWhitespace()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 1));
            Assert.Throws<ArgumentNullException>(() => new Gym("", 2));
        }

        [Test]
        public void VerifyCollection()
        {
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void VerifyCapacityProperty()
        {
            Assert.AreEqual(2, gym.Capacity, "Property isn't working right!");
        }

        [Test]
        public void CapacityPropertyThrowsExceptionIfValueIsNegative()
        {
            Assert.Throws<ArgumentException>(() => gym = new Gym("Arrr", -1));
        }

        [Test]
        public void VerifyAddMethod()
        {
            Athlete temp = new Athlete("Momo");
            gym.AddAthlete(temp);

            Assert.AreEqual(2, gym.Count);
        }

        [Test]
        public void AddMethodThrowsExceptionWhenCollectionReachesAllowedCapacity()
        {
            Athlete temp = new Athlete("Momo");
            gym.AddAthlete(temp);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("Pepe")));
        }

        [Test]
        public void VerifyRemoveMethod()
        {
            gym.RemoveAthlete("Kiril");
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void RemoveMethodThrowsExceptionWhenEntityIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete(null));
        }

        [Test]
        public void VerifyInjuredMethod()
        {
            athlete.IsInjured = true;

            Assert.AreEqual(athlete, gym.InjureAthlete("Kiril"));
        }

        [Test]
        public void InjuredMethodThrowsExceptionWhenEntityIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete(null));
        }

        [Test]
        public void VerifyReportMethod()
        {
            string expectedMessage = $"Active athletes at {gym.Name}: {athlete.FullName}";

            Assert.AreEqual(expectedMessage, gym.Report());
        }

    }
}