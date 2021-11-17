using System;
using NUnit.Framework;

namespace CarManager.Tests
{
    public class CarTests
    {
        private Car car;
        private double fuelAmount;

        [SetUp]
        public void Setup()
        {
            car = new Car("Audi", "A3", 40, 100);
            fuelAmount = 0;
        }

        [Test]
        public void VerifyConstructor()
        {
            Assert.IsNotNull(car, "The constructor is broken!");
        }

        [Test]
        public void VerifyMakeProperty()
        {
            Assert.AreEqual("Audi", car.Make, "Property isn't working right!");
        }

        [Test]
        public void MakePropertyThrowsExceptionIfNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => car = new Car(null, "Some", 10, 10));
        }

        [Test]
        public void VerifyModelProperty()
        {
            Assert.AreEqual("A3", car.Model, "Property isn't working right!");
        }

        [Test]
        public void ModelPropertyThrowsExceptionIfNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Some", null, 10, 10));
        }

        [Test]
        public void VerifyFuelConsProperty()
        {
            Assert.AreEqual(40, car.FuelConsumption, "Property isn't working right!");
        }

        [Test]
        public void FuelConsPropertyThrowsExceptionIfValueIsNegativeOrZero()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Some", "Car", 0, 10));
            Assert.Throws<ArgumentException>(() => car = new Car("Some", "Car", -10, 10));
        }

        [Test]
        public void VerifyFuelAmountProperty()
        {
            Assert.AreEqual(0, car.FuelAmount, "Property isn't working right!");
        }

        [Test]
        public void FuelAmountPropertyThrowsExceptionIfValueIsNegative()
        {
            Assert.That(() => car.Refuel(0), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void VerifyFuelCapacityProperty()
        {
            Assert.AreEqual(100, car.FuelCapacity, "Property isn't working right!");
        }

        [Test]
        public void FuelCapacityPropertyThrowsExceptionIfValueIsNegativeOrZero()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Some", "Car", 10, 0));
            Assert.Throws<ArgumentException>(() => car = new Car("Some", "Car", 10, -10));
        }

        [Test]
        public void VerifyRefuelMethod()
        {
            car.Refuel(20);
            double currentAmount = car.FuelAmount;
            double expected = 20;
            Assert.AreEqual(expected, currentAmount, "The car isn't refueling right!");
        }

        [Test]
        public void FuelIsSetToMaxCapacityWhenGoingOverTheAllowed()
        {
            car.Refuel(150);
            double currentAmount = car.FuelAmount;
            Assert.AreEqual(car.FuelCapacity, currentAmount);
        }

        [Test]
        public void RefuelMethodThrowsExceptionIfValueIsNegativeOrZero()
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(0));
            Assert.Throws<ArgumentException>(() => car.Refuel(-10));
        }

        [Test]
        public void VerifyDriveMethod()
        {
            car.Refuel(30);
            car.Drive(30);
            double expected = 18;
            double currentAmount = car.FuelAmount;
            Assert.AreEqual(expected, currentAmount, "The method isn't working right!");
        }

        [Test]
        public void DriveMethodThrowsExceptionIfFuelNeededIsLessThanCurrentAmount()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(200.00));
        }
    }
}
