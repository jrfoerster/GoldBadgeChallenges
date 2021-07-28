using _01_Cafe.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_Cafe.Tests
{
    [TestClass]
    public class MenuRepositoryTests
    {
        private readonly MenuRepository _repository = new MenuRepository();

        [TestInitialize]
        public void Initialize()
        {
            _repository.Add(new Menu() { Name = "Double Bacon Burger Combo" });
            _repository.Add(new Menu() { Name = "Triple Combo" });
            _repository.Add(new Menu() { Name = "Spicy Chicken Combo" });
        }

        [TestMethod]
        public void MenuRepository_Count()
        {
            Assert.AreEqual(3, _repository.Count);
        }

        [TestMethod]
        public void MenuRepository_Get()
        {
            string expected = "Double Bacon Burger Combo";
            string actual = _repository.Get(0).Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_GetAll()
        {
            foreach (var menu in _repository.GetAll())
            {
                Assert.IsNotNull(menu.Name);
                Console.WriteLine(menu.Name);
            }
        }

        [TestMethod]
        public void MenuRepository_Add()
        {
            int index = _repository.Count;
            Menu expected = new Menu() { Name = "Grilled Cheese Combo" };
            _repository.Add(expected);
            Menu actual = _repository.Get(index);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_DeleteIsInRepo_ReturnsTrue()
        {
            int testIndex = 0;
            bool condition = _repository.Delete(testIndex);
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void MenuRepository_DeleteNotInRepo_ReturnsFalse()
        {
            int testIndex = -1;
            bool condition = _repository.Delete(testIndex);
            Assert.IsFalse(condition);
        }
    }
}
