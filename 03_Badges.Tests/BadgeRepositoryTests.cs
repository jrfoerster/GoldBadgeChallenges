using _03_Badges.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace _03_Badges.Tests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        [TestMethod]
        public void BadgeRepository_AddSafe_BadgeWithUniqueID_ReturnsTrue()
        {
            var repository = new BadgeRepository();
            var badge = new Badge(0);
            bool condition = repository.AddSafe(badge);
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void BadgeRepository_AddSafe_BadgeWithDuplicateID_ReturnsFalse()
        {
            var repository = new BadgeRepository();
            int id = 0;
            repository.AddSafe(new Badge(id));
            bool condition = repository.AddSafe(new Badge(id));
            Assert.IsFalse(condition);
        }

        [TestMethod]
        public void BadgeRepository_Count_NewRepository_AreEqual()
        {
            var repository = new BadgeRepository();
            int expected = 0;
            int actual = repository.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BadgeRepository_Count_AfterAdd_AreEqual()
        {
            var repository = new BadgeRepository();
            repository.Add(new Badge(0));
            int expected = 1;
            int actual = repository.Count;
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(int.MinValue)]
        [DataRow(int.MaxValue)]
        public void BadgeRepository_Contains_AfterAdd_ReturnsTrue(int id)
        {
            var repository = new BadgeRepository();
            repository.Add(new Badge(id));
            bool condition = repository.Contains(id);
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void BadgeRepository_Get_IsInRepo_AreEqual()
        {
            var repository = new BadgeRepository();
            int id = 0;
            var expected = new Badge(id);
            repository.Add(expected);
            var actual = repository.Get(id);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BadgeRepository_GetAll_AreEqual()
        {
            var expected = new Badge[]
            {
                new Badge(0),
                new Badge(1),
                new Badge(2)
            };

            var repository = new BadgeRepository();
            foreach (var badge in expected)
            {
                repository.Add(badge);
            }
            List<Badge> actual = repository.GetAll().ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}