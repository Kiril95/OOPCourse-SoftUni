using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private Item item;
        private BankVault vault;

        [SetUp]
        public void Setup()
        {
            item = new Item("Kireto", "13");
            vault = new BankVault();
            vault.AddItem("A1", item);
        }

        [Test]
        public void VerifyConstructor()
        {
            Assert.IsNotNull(item, "The constructor is broken!");
            Assert.IsNotNull(vault, "The constructor is broken!");
        }

        [Test]
        public void VerifyItem()
        {
            Assert.AreEqual(vault.VaultCells.TryGetValue("A1", out var temp), true);
        }

        [Test]
        public void VerifyItemProperties()
        {
            string expOwner = "Kireto";
            string expId = "13";

            Assert.AreEqual(expOwner, item.Owner);
            Assert.AreEqual(expId, item.ItemId);
        }

        [Test]
        public void VerifyIReadOnlyDictionary()
        {
            var expectedCollection = vault.VaultCells;
            Assert.True(expectedCollection is IReadOnlyDictionary<string, Item>);
        }

        [Test]
        public void VerifyAddItemMethod()
        {
            Item temp = new Item("Kobrata", "10");
            string expected = $"Item:{temp.ItemId} saved successfully!";

            Assert.AreEqual(expected, vault.AddItem("A2", temp));
        }

        [Test]
        public void AddItemMethodThrowsExceptionWhenSearchedCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => vault.AddItem("666", item));
        }

        [Test]
        public void AddItemMethodThrowsExceptionWhenCellIsTaken()
        {
            Assert.Throws<ArgumentException>(() => vault.AddItem("A1", new Item("Jojo", "2")));
        }

        [Test]
        public void AddItemMethodThrowsExceptionWhenItemIsAlreadyInCell()
        {
            Assert.Throws<InvalidOperationException>(() => vault.AddItem("A3", item));
        }

        [Test]
        public void VerifyRemoveMethod()
        {
            string expected = $"Remove item:{item.ItemId} successfully!";

            Assert.AreEqual(expected, vault.RemoveItem("A1", item));
        }

        [Test]
        public void RemoveMethodThrowsExceptionWhenSearchedCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("666", item));
        }

        [Test]
        public void RemoveMethodThrowsExceptionWhenItemDoesNotExist()
        {
            Item temp = new Item("Pepe", "1");
            vault.AddItem("A4", temp);
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("A4", item));
        }
    }
}