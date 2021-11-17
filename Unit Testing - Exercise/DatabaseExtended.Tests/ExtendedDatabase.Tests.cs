using NUnit.Framework;
using System;

namespace DatabaseExtended.Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private const int AllowedCapacity = 16;
        private ExtendedDatabase extDatabase;
        private Person[] people;
        private Person firstPerson;
        private Person secondPerson;

        private Person[] FillCollection()
        {
            Person[] persons = new Person[AllowedCapacity];
            for (int i = 0; i < 16; i++)
            {
                var userName = "Guy" + i;
                var person = new Person(i + 1, userName);
                persons[i] = person;
            }

            return persons;
        }

        [SetUp]
        public void Setup()
        {
            firstPerson = new Person(123, "Kircho");
            secondPerson = new Person(321, "Mircho");
            people = new[] {firstPerson, secondPerson};
            extDatabase = new ExtendedDatabase();
        }

        [Test]
        public void VerifyConstructor()
        {
            var db = new ExtendedDatabase(people);
            Assert.IsNotNull(db);
        }

        [Test]
        public void VerifyCollectionSize()
        {
            people = new[] { firstPerson, secondPerson , new Person(1, "pepe")};
            Assert.AreEqual(3, people.Length);
        }

        [Test]
        public void VerifyAddRangeMethod()
        {
            int expected = 2;
            extDatabase = new ExtendedDatabase(people);
            Assert.AreEqual(expected, extDatabase.Count, "This method doesn't work right!");
        }

        [Test]
        public void CollectionThrowsExceptionWhenGoingOverTheCapacity()
        {
            Person[] data = new Person[AllowedCapacity + 1];
            var error = Assert.Throws<ArgumentException>(() => extDatabase = new ExtendedDatabase(data));
            Assert.AreEqual("Provided data length should be in range [0..16]!", error.Message);
        }

        [Test]
        public void VerifyAddMethod()
        {
            extDatabase = new ExtendedDatabase(people);
            var newPerson = new Person(777, "Bojkov");
            extDatabase.Add(newPerson);
            int expected = 3;
            Assert.AreEqual(expected, extDatabase.Count);
        }

        [Test]
        public void AddMethodThrowsExceptionWhenGoingOverTheCapacity()
        {
            Person[] temp = this.FillCollection();
            extDatabase = new ExtendedDatabase(temp);
            Assert.Throws<InvalidOperationException>(() => extDatabase.Add(new Person(11, "Pepe")));
        }

        [Test]
        public void AddMethodThrowsExceptionIfCollectionSizeIs16()
        {
            var temp = this.FillCollection();
            extDatabase = new ExtendedDatabase(temp);
            Assert.Throws<InvalidOperationException>(() => extDatabase.Add(null));
        }

        [Test]
        public void AddMethodThrowsExceptionWhenTheSameUserIsFound()
        {
            extDatabase.Add(firstPerson);
            Assert.Throws<InvalidOperationException>(() => extDatabase.Add(new Person(11, "Kircho")));
        }

        [Test]
        public void AddMethodThrowsExceptionWhenTheSameIdIsFound()
        {
            extDatabase.Add(firstPerson);
            Assert.Throws<InvalidOperationException>(() => extDatabase.Add(new Person(123, "Gandalf")));
        }

        [Test]
        public void VerifyRemoveMethod()
        {
            extDatabase = new ExtendedDatabase(people);
            extDatabase.Remove();
            int expected = 1;
            Assert.AreEqual(expected, extDatabase.Count, "This method doesn't work right!");
        }

        [Test]
        public void RemoveMethodThrowsExceptionWhenCollectionIsEmpty()
        {
            extDatabase = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => extDatabase.Remove());
        }

        [Test]
        public void VerifyFindByUserNameMethod()
        {
            extDatabase = new ExtendedDatabase(people);
            var target = extDatabase.FindByUsername(secondPerson.UserName);
            Assert.AreEqual(secondPerson.UserName, target.UserName, "This method doesn't work right!");
            Assert.AreEqual(secondPerson.Id, target.Id, "This method doesn't work right!");
        }

        [Test]
        public void FindByUserNameMethodThrowsExceptionWhenParameterIsNull()
        {
            extDatabase = new ExtendedDatabase(people);
            Assert.Throws<ArgumentNullException>(() => extDatabase.FindByUsername(null));
        }

        [Test]
        public void FindByUserNameMethodThrowsExceptionWhenParameterIsEmpty()
        {
            extDatabase = new ExtendedDatabase(people);
            Assert.Throws<ArgumentNullException>(() => extDatabase.FindByUsername(string.Empty));
        }

        [Test]
        public void FindByUserNameMethodThrowsExceptionWhenUserIsNotFound()
        {
            extDatabase = new ExtendedDatabase(people);
            Assert.Throws<InvalidOperationException>(() => extDatabase.FindByUsername("Mile Kitic"));
        }

        [Test]
        public void FindByUserNameMethodIsCaseSensitive()
        {
            extDatabase = new ExtendedDatabase(people);
            Assert.Throws<InvalidOperationException>(() => extDatabase.FindByUsername("MIRCHO"));
        }

        [Test]
        public void VerifyFindByIdMethod()
        {
            extDatabase = new ExtendedDatabase(people);
            var target = extDatabase.FindById(firstPerson.Id);
            Assert.AreEqual(firstPerson.Id, target.Id, "This method doesn't work right!");
            Assert.AreEqual(firstPerson.UserName, target.UserName, "This method doesn't work right!");
        }

        [Test]
        public void FindByIdMethodThrowsExceptionWhenParameterIsNegative()
        {
            extDatabase = new ExtendedDatabase(people);
            Assert.Throws<ArgumentOutOfRangeException>(() => extDatabase.FindById(-123));
        }

        [Test]
        public void FindByIdMethodThrowsExceptionWhenIdIsNotFound()
        {
            extDatabase = new ExtendedDatabase(people);
            Assert.Throws<InvalidOperationException>(() => extDatabase.FindById(666));
        }
    }
}