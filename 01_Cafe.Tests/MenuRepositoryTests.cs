using _01_Cafe.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_Cafe.Tests
{
    [TestClass]
    public class MenuRepositoryTests
    {
        private MenuRepository _repository;

        public void Initialize()
        {
            _repository = new MenuRepository();
            _repository.Add(new Menu() { Name = "Double Bacon Burger Combo" });
            _repository.Add(new Menu() { Name = "Triple Combo" });
            _repository.Add(new Menu() { Name = "Spicy Chicken Combo" });
            _repository.Add(new Menu() { Name = "Double Spicy Chicken Combo" });
            _repository.Add(new Menu() { Name = "Triple Spicy Chicken Combo" });
        }

        [TestMethod]
        public void MenuRepository_Get()
        {
            Initialize();
            int firstIndex = 1;
            string expected = "Double Bacon Burger Combo";
            string actual = _repository.Get(firstIndex).Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_GetAll()
        {
            Initialize();
            foreach (var menu in _repository.GetAll())
            {
                Assert.IsNotNull(menu.Name);
                Console.WriteLine(menu.Name);
            }
        }

        [TestMethod]
        public void MenuRepository_AddAndThenGetLastItem_AreEqual()
        {
            Initialize();
            Menu expected = new Menu() { Name = "Grilled Cheese Combo" };
            _repository.Add(expected);
            int index = _repository.Count;
            Menu actual = _repository.Get(index);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_AddMenuWithNumberAlreadySet_AreEqual()
        {
            Initialize();
            Menu menu = new Menu() { Number = int.MaxValue };
            _repository.Add(menu);
            int expected = _repository.Count;
            int actual = menu.Number;
            Console.WriteLine($"{expected} - {actual}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_DeleteIsInRepo_ReturnsTrue()
        {
            Initialize();
            int testIndex = 1;
            bool condition = _repository.Delete(testIndex);
            Assert.IsTrue(condition);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(int.MinValue)]
        [DataRow(int.MaxValue)]
        public void MenuRepository_DeleteIsNotInRepo_ReturnsFalse(int testIndex)
        {
            Initialize();
            bool condition = _repository.Delete(testIndex);
            Assert.IsFalse(condition);
        }

        [TestMethod]
        public void MenuRepository_DeleteAreMenuNumbersUpdated_AreEqual()
        {
            Initialize();
            int firstIndex = 1;
            _repository.Delete(firstIndex);
            int expected = firstIndex;
            foreach (Menu menu in _repository.GetAll())
            {
                int actual = menu.Number;
                Console.WriteLine(actual);
                Assert.AreEqual(expected, actual);
                expected++;
            }
        }
    }
}
