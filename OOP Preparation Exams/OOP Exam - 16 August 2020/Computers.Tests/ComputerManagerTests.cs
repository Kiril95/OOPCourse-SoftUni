using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer computer;
        private ComputerManager manager;

        [SetUp]
        public void Setup()
        {
            computer = new Computer("Velocity", "Raptor", 5000);
            manager = new ComputerManager();
            manager.AddComputer(computer);
        }

        [Test]
        public void VerifyConstructor()
        {
            Assert.IsNotNull(computer, "The constructor is broken!");
            Assert.IsNotNull(manager, "The constructor is broken!");
        }

        [Test]
        public void VerifyIReadOnlyCollection()
        {
            var expectedCollection = manager.Computers;
            Assert.True(expectedCollection is IReadOnlyCollection<Computer>);
        }

        [Test]
        public void VerifyCountMethod()
        {
            Assert.AreEqual(1, manager.Count);
        }

        [Test]
        public void VerifyAddComputerMethod()
        {
            Computer temp = new Computer("Bla", "Blabla", 5);
            manager.AddComputer(temp);

            Assert.AreEqual(2, manager.Count);
        }

        [Test]
        public void AddComputerMethodThrowsExceptionWhenComputerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => manager.AddComputer(null));
        }

        [Test]
        public void AddComputerMethodThrowsExceptionWhenComputerExists()
        {
            Assert.Throws<ArgumentException>(() => manager.AddComputer(computer));
        }

        [Test]
        public void VerifyRemoveComputerMethod()
        {
            Computer comp = computer;

            Assert.AreEqual(comp, manager.RemoveComputer(computer.Manufacturer, computer.Model));
        }

        [Test]
        public void RemoveMethodDecreasesCount()
        {
            manager.RemoveComputer(computer.Manufacturer, computer.Model);

            Assert.AreEqual(0, manager.Count);
        }

        [TestCase(null)]
        public void RemoveComputerMethodThrowsExceptionWhenOneOfTheParametersIsNull(string value)
        {
            Computer temp = new Computer("HP", "Device200", 700);
            manager.AddComputer(temp);

            Assert.Throws<ArgumentNullException>(() => manager.RemoveComputer(value, "J230"));
            Assert.Throws<ArgumentNullException>(() => manager.RemoveComputer("HP", value));
        }

        [Test]
        public void VerifyGetComputerMethod()
        {
            Computer temp = new Computer("Bla", "Blabla", 5);

            Assert.AreEqual(computer, manager.GetComputer(computer.Manufacturer, computer.Model));
        }

        [Test]
        public void GetComputerMethodThrowsExceptionWhenComputerIsNotFound()
        {
            Assert.Throws<ArgumentException>(() => manager.GetComputer("Some", "Comp"));
        }

        [Test]
        public void GetComputerMethodThrowsExceptionWhenManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(null, computer.Model));
        }

        [Test]
        public void GetComputerMethodThrowsExceptionWhenModelIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(computer.Manufacturer, null));
        }

        [Test]
        public void VerifyGetComputersByManufacturerMethod()
        {
            ICollection<Computer> computers = manager.Computers
                .Where(c => c.Manufacturer == computer.Manufacturer)
                .ToList();
            var result = manager.GetComputersByManufacturer(computer.Manufacturer);

            CollectionAssert.AreEqual(computers, result);
        }

        [Test]
        public void GetComputersByManufacturerMethodThrowsExceptionWhenManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => manager.GetComputersByManufacturer(null));
        }
    }
}