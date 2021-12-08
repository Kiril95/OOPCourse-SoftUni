using System;
using NUnit.Framework;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        private UnitCar uCar;
        private UnitDriver uDriver;
        private RaceEntry entry;

        [SetUp]
        public void Setup()
        {
            uCar = new UnitCar("Audi", 125, 2000);
            uDriver = new UnitDriver("Kirchaka", uCar);
            entry = new RaceEntry();
            entry.AddDriver(uDriver);
        }

        [Test]
        public void VerifyConstructor()
        {
            Assert.IsNotNull(uCar, "The constructor is broken!");
            Assert.IsNotNull(uDriver, "The constructor is broken!");
            Assert.IsNotNull(entry, "The constructor is broken!");
        }

        [Test]
        public void NamePropertyThrowsExceptionIfNull()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitDriver(null, uCar));
        }

        [Test]
        public void VerifyUnitCar()
        {
            string model = "Audi";
            int horseP = 125;
            double cubics = 2000;
            Assert.AreEqual(model, uCar.Model);
            Assert.AreEqual(horseP, uCar.HorsePower);
            Assert.AreEqual(cubics, uCar.CubicCentimeters);
        }

        [Test]
        public void VerifyCountMethod()
        {
            Assert.AreEqual(1, entry.Counter);
        }

        [Test]
        public void VerifyAddDriverMethod()
        {
            entry.AddDriver(new UnitDriver("Jacky", new UnitCar("Tesla", 666, 5000)));

            Assert.AreEqual(2, entry.Counter);
        }

        [Test]
        public void AddDriverMethodThrowsExceptionWhenDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => entry.AddDriver(null));
        }

        [Test]
        public void AddDriverMethodThrowsExceptionWhenDriverExists()
        {
            Assert.Throws<InvalidOperationException>(() => entry.AddDriver(new UnitDriver("Kirchaka", uCar)));
        }

        [Test]
        public void CalculateAverageHorsePowerMethodThrowsExceptionWhenDriversCountIsBellowTheAllowed()
        {
            Assert.Throws<InvalidOperationException>(() => entry.CalculateAverageHorsePower());
        }

        [Test]
        public void VerifyCalculateAverageHorsePowerMethod()
        {
            entry.AddDriver(new UnitDriver("Elon", new UnitCar("Tesla", 666, 5000)));

            Assert.AreEqual(395.5d, entry.CalculateAverageHorsePower());
        }

    }
}