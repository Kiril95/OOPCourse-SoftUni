using System;
using System.Collections.Generic;

namespace Presents.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private Bag bag;

        [SetUp]
        public void Setup()
        {
            present = new Present("Scepter", 50);
            bag = new Bag();
            bag.Create(present);
        }

        [Test]
        public void VerifyConstructor()
        {
            Assert.IsNotNull(present, "The constructor is broken!");
            Assert.IsNotNull(bag, "The constructor is broken!");
        }

        [Test]
        public void VerifyCreateMethod()
        {
            Present temp = new Present("Wand", 5);
            string expMess = $"Successfully added present {temp.Name}.";

            Assert.AreEqual(expMess, bag.Create(temp));
        }

        [Test]
        public void CreateMethodThrowsExceptionWhenPresentIsNull()
        {
            present = null;
            Assert.Throws<ArgumentNullException>(() => bag.Create(present));
        }

        [Test]
        public void CreateMethodThrowsExceptionWhenEntityExists()
        {
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void VerifyRemoveMethod()
        {
            Present temp = new Present("Bla", 5);
            bag.Create(temp);
            Assert.AreEqual(true, bag.Remove(temp));
        }

        [Test]
        public void VerifyGetPresentWithLeastMagicMethod()
        {
            Present temp = new Present("Wand", 10);
            bag.Create(temp);
            Assert.AreEqual(temp, bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void VerifyGetPresentMethod()
        {
            Assert.AreEqual(present, bag.GetPresent(present.Name));
        }

        [Test]
        public void VerifyReadOnlyCollection()
        {
            var expectedCollection = bag.GetPresents();
            Assert.True(expectedCollection is IReadOnlyCollection<Present>);
        }
    }
}
