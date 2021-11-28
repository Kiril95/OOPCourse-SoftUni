using NUnit.Framework;

namespace Robots.Tests
{
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager storage;

        [SetUp]
        public void Setup()
        {
            robot = new Robot("R2-D2", 80);
            storage = new RobotManager(2);
            storage.Add(robot);
        }

        [Test]
        public void VerifyConstructor()
        {
            Assert.IsNotNull(robot, "The constructor is broken!");
            Assert.IsNotNull(storage, "The constructor is broken!");
        }

        [Test]
        public void VerifyCapacityProperty()
        {
            Assert.AreEqual(2, storage.Capacity, "Property isn't working right!");
        }

        [Test]
        public void CapacityPropertyThrowsExceptionIfValueIsBellowZero()
        {
            Assert.Throws<ArgumentException>(() => storage = new RobotManager(-10));
        }

        [Test]
        public void VerifyCountMethod()
        {
            Assert.AreEqual(1, storage.Count, "Method isn't working right!");
        }

        [Test]
        public void VerifyAddMethod()
        {
            int expected = 2;
            Robot temp = new Robot("Temp", 2);
            storage.Add(temp);
            Assert.AreEqual(expected, storage.Count);
        }

        [Test]
        public void AddMethodThrowsExceptionWhenRobotWithTheSameNameIsFound()
        {
            Assert.Throws<InvalidOperationException>(() => storage.Add(new Robot("R2-D2", 5)));
        }

        [Test]
        public void AddMethodThrowsExceptionWhenGoingOverTheCapacity()
        {
            Robot temp = new Robot("Temp", 2);
            storage.Add(temp);
            Assert.Throws<InvalidOperationException>(() => storage.Add(new Robot("R2", 5)));
        }

        [Test]
        public void VerifyRemoveMethod()
        {
            Robot temp = new Robot("Temp", 2);
            storage.Add(temp);
            storage.Remove(temp.Name);
            Assert.AreEqual(1, storage.Count);
        }

        [Test]
        public void RemoveMethodThrowsExceptionWhenRobotEntityIsNull()
        {
            robot = null;
            Assert.Throws<InvalidOperationException>(() => storage.Remove(robot?.Name));
        }

        [Test]
        public void RemoveMethodThrowsExceptionWhenNoSuchRobotIsFound()
        {
            Assert.Throws<InvalidOperationException>(() => storage.Remove("Goshko"));
        }

        [Test]
        public void VerifyWorkMethod()
        {
            storage.Work(robot.Name, "Engineering", 20);
            Assert.AreEqual(60, robot.Battery);
        }

        [Test]
        public void WorkMethodThrowsExceptionWhenRobotEntityIsNull()
        {
            robot = null;
            Assert.Throws<InvalidOperationException>(() => storage.Work(robot?.Name, "Cleaning", 20));
        }

        [Test]
        public void WorkMethodThrowsExceptionWhenHavingLessBatteryCapacityThanNeeded()
        {
            Robot temp = new Robot("Toshko", 20);
            storage.Add(temp);
            Assert.Throws<InvalidOperationException>(() => storage.Work(temp.Name, "Cleaning", 555));
        }

        [Test]
        public void VerifyChargeMethod()
        {
            storage.Work(robot.Name, "Drinking", 30);
            storage.Charge(robot.Name);
            Assert.AreEqual(80, robot.Battery);
        }

        [Test]
        public void ChargeMethodThrowsExceptionWhenRobotEntityIsNull()
        {
            robot = null;
            Assert.Throws<InvalidOperationException>(() => storage.Charge(robot?.Name));
        }
    }
}
