using _03_Badges.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _03_Badges.Tests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        [TestMethod]
        public void BadgeRepository_AddBadgeWithUniqueID_ReturnsTrue()
        {
            var repository = new BadgeRepository();
            var badge = new Badge(0);
            bool condition = repository.AddSafe(badge);
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void BadgeRepository_AddBadgeWithDuplicateID_ReturnsFalse()
        {
            var repository = new BadgeRepository();
            int id = 0;
            repository.AddSafe(new Badge(id));
            bool condition = repository.AddSafe(new Badge(id));
            Assert.IsFalse(condition);
        }
    }
}