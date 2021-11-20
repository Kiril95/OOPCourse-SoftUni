using System;
using System.Collections.Generic;
using Chainblock.Contracts;
using Chainblock.Enumerators;
using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private ITransaction transaction;
        private IChainblock chainblock;

        [SetUp]
        public void SetUp()
        {
            transaction = new Transaction(123, TransactionStatus.Successfull, "Kircho", "Fircho", 1);
            chainblock = new Models.Chainblock();
        }

        [Test]
        public void VerifyAddMethod()
        {
            chainblock.Add(transaction);
            int expectedResult = 1;
            int actualResult = chainblock.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddMethodThrowsExceptionIfSameIdTransactionIsGiven()
        {
            chainblock.Add(transaction);
            Assert.Throws<ArgumentException>(() => chainblock.Add(transaction));
        }

        [Test]
        public void VerifyContainsByTransactionMethod()
        {
            chainblock.Add(transaction);
            Assert.IsTrue(chainblock.Contains(transaction));
        }

        [Test]
        public void ContainsByTransactionMethodReturnsFalseIfTransactionIsPresent()
        {
            Assert.IsFalse(chainblock.Contains(transaction));
        }

        [Test]
        public void VerifyContainsByIdMethod()
        {
            chainblock.Add(transaction);
            Assert.IsTrue(chainblock.Contains(123));
        }

        [Test]
        public void ContainsByIdMethodReturnsFalseIfIdIsPresent()
        {
            Assert.IsFalse(chainblock.Contains(12345));
        }

        [Test]
        public void VerifyChangeTransactionStatusMethod()
        {
            chainblock.Add(transaction);
            chainblock.ChangeTransactionStatus(123, TransactionStatus.Failed);
            var expectedResult = TransactionStatus.Failed;
            var actualResult = transaction.Status;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ChangeTransactionStatusMethodThrowsExceptionIfTransactionWithGivenIdDoesNotExist()
        {
            chainblock.Add(transaction);
            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(12345, TransactionStatus.Failed));
        }

        [Test]
        public void VerifyRemoveByIdMethod()
        {
            chainblock.Add(transaction);
            chainblock.RemoveTransactionById(123);
            var expectedResult = 0;
            var actualResult = chainblock.Count; ;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveByIdMethodThrowsExceptionIfTransactionDoesNotExist()
        {
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(12345));
        }

        [Test]
        public void VerifyGetByIdMethod()
        {
            chainblock.Add(transaction);
            var expectedResult = transaction;
            var actualResult = chainblock.GetById(123);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByIdMethodThrowsExceptionIfTransactionDoesNotExist()
        {
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(12345));
        }

        [Test]
        public void VerifyGetByTransactionStatusMethod()
        {
            var transaction2 = new Transaction(12345, TransactionStatus.Successfull, "Gosho", "Pesho", 100);
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            var expectedResult = new ITransaction[] { transaction2, transaction };
            var actualResult = chainblock.GetByTransactionStatus(TransactionStatus.Successfull);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByTransactionStatusMethodThrowsExceptionIfTransactionStatusIsWrong()
        {
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void VerifyGetAllSendersWithTransactionStatusMethod()
        {
            var transaction2 = new Transaction(12345, TransactionStatus.Successfull, "Kircho", "Fircho", 100);
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            var expectedResult = new string[] { "Kircho", "Kircho" };
            var actualResult = chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusMethodThrowsExceptionIfTransactionStatusIsWrong()
        {
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void VerifyGetAllReceiversWithTransactionStatusMethod()
        {
            var transaction2 = new Transaction(12345, TransactionStatus.Successfull, "Kircho", "Fircho", 100);
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            var expectedResult = new string[] { "Fircho", "Fircho" };
            var actualResult = chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusMethodThrowsExceptionIfTransactionStatusIsWrong()
        {
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void VerifyGetAllOrderedByAmountDescendingThenByIdMethod()
        {
            var transaction2 = new Transaction(123456, TransactionStatus.Successfull, "Gosho", "Pesho", 100);
            var transaction3 = new Transaction(12345, TransactionStatus.Successfull, "Gosho", "Pesho", 100);
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            var expectedResult = new ITransaction[] { transaction2, transaction3, transaction };
            var actualResult = chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void VerifyGetAllOrderedByAmountDescendingThenReturnAll()
        {
            var transaction2 = new Transaction(123456, TransactionStatus.Successfull, "Kircho", "Fircho", 100);
            var transaction3 = new Transaction(12345, TransactionStatus.Successfull, "Toshko", "Pesho", 100);
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            var expectedResult = new ITransaction[] { transaction2, transaction };
            var actualResult = chainblock.GetBySenderOrderedByAmountDescending("Kircho");

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingMethodThrowsExceptionIfSenderDoesNotExist()
        {
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderOrderedByAmountDescending("Toshko"));
        }

        [Test]
        public void VerifyGetByReceiverOrderedByAmountThenByIdMethod()
        {
            var transaction2 = new Transaction(123456, TransactionStatus.Successfull, "Kircho", "Fircho", 100);
            var transaction3 = new Transaction(12345, TransactionStatus.Successfull, "Toshko", "Fircho", 100);
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            var expectedResult = new ITransaction[] { transaction3, transaction2, transaction };
            var actualResult = chainblock.GetByReceiverOrderedByAmountThenById("Fircho");

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdMethodThrowsExceptionIfReceiverDoesNotExist()
        {
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverOrderedByAmountThenById("Toshko"));
        }

        [Test]
        public void VerifyGetByTransactionStatusAndMaximumAmountMethod()
        {
            var transaction2 = new Transaction(123456, TransactionStatus.Successfull, "Gosho", "Pesho", 100);
            var transaction3 = new Transaction(12345, TransactionStatus.Failed, "Toshko", "Pesho", 100); ;
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            var expectedResult = new ITransaction[] { transaction };
            var actualResult = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 50);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountMethodReturnsEmptyCollectionIfFailed()
        {
            chainblock.Add(transaction);
            List<ITransaction> expectedResult = new List<ITransaction>();
            var actualResult = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Failed, 50);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountMethodReturnsAllTransactionsOrdered()
        {
            var transaction2 = new Transaction(123456, TransactionStatus.Successfull, "Gosho", "Pesho", 100);
            var transaction3 = new Transaction(12345, TransactionStatus.Successfull, "Gosho", "Pesho", 150);
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            var expectedResult = new ITransaction[] { transaction3, transaction2 };
            var actualResult = chainblock.GetBySenderAndMinimumAmountDescending("Gosho", 1);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingMethodThrowsExceptionIfSenderDoesNotExist()
        {
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderAndMinimumAmountDescending("Toshko", 50));
        }

        [Test]
        public void VerifyGetByReceiverAndAmountRangeMethod()
        {
            var transaction2 = new Transaction(123456, TransactionStatus.Successfull, "Kircho", "Fircho", 100);
            var transaction3 = new Transaction(12345, TransactionStatus.Successfull, "Toshko", "Fircho", 100);
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            var expectedResult = new ITransaction[] { transaction };
            var actualResult = chainblock.GetByReceiverAndAmountRange("Fircho", 1, 100);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetByReceiverAndAmountRangeMethodThrowsExceptionIfReceiverDoesNotExist()
        {
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("Toshko", 50, 100));
        }

        [Test]
        public void VerifyGetAllInAmountRangeMethod()
        {
            var transaction2 = new Transaction(123456, TransactionStatus.Successfull, "Gosho", "Pesho", 100);
            var transaction3 = new Transaction(12345, TransactionStatus.Failed, "Toshko", "Pesho", 100); ;
            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            var expectedResult = new ITransaction[] { transaction, transaction2, transaction3 };
            var actualResult = chainblock.GetAllInAmountRange(1, 100);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetAllInAmountRangeMethodReturnsEmptyCollectionIfNoTransactionsArePresent()
        {
            chainblock.Add(transaction);
            List<ITransaction> expectedResult = new List<ITransaction>();
            var actualResult = chainblock.GetAllInAmountRange(150, 250);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}