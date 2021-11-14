using NUnit.Framework;
using System;

namespace Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private const int AllowedCapacity = 16;
        private Database dataBase;
        private void FillCollection(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                this.dataBase.Add(i);
            }
        }

        [SetUp]
        public void Setup()
        {
            dataBase = new Database(AllowedCapacity);
        }
        
        [Test]
        public void VerifyCollectionSize()
        {
            this.FillCollection(AllowedCapacity - 1);
            Assert.AreEqual(AllowedCapacity, dataBase.Count, "The method isn't working right!");
        }

        [Test]
        public void VerifyAddMethod()
        {
            this.FillCollection(AllowedCapacity - 1);
            Assert.Throws<InvalidOperationException>(() => this.dataBase.Add(1));
        }

        [Test]
        public void VerifyRemoveMethod()
        {
            int expectResult = dataBase.Count - 1;
            dataBase.Remove();
            Assert.AreEqual(expectResult, dataBase.Count, "The method isn't working right!");
        }

        [Test]
        public void CollectionThrowsExceptionWhenGoingOverTheCapacity()
        {
            var error = Assert.Throws<InvalidOperationException>(() => this.FillCollection(AllowedCapacity));
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", error.Message);
        }

        [Test]
        public void CollectionThrowsExceptionWhenEmpty()
        {
            dataBase = new Database();
            var error = Assert.Throws<InvalidOperationException>(() => this.dataBase.Remove());
            Assert.AreEqual("The collection is empty!", error.Message);
        }

        [Test]
        public void VerifyFetchMethod()
        {
            int[] collection = this.dataBase.Fetch();
            Assert.AreEqual(this.dataBase.Count, collection.Length, "The collections aren't equal!");
        }
    }
}