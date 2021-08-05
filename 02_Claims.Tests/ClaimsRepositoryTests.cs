using _02_Claims.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Claims.Tests
{
    [TestClass]
    public class ClaimsRepositoryTests
    {
        [TestMethod]
        public void ClaimsRepository_Count()
        {
            var repository = new ClaimsRepository();
            int expected = 0;
            int actual = repository.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimsRepository_Add()
        {
            var repository = new ClaimsRepository();
            repository.Add(new Claim());
            int expected = 1;
            int actual = repository.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimsRepository_SeeNextClaim()
        {
            var repository = new ClaimsRepository();
            var expected = new Claim();
            repository.Add(expected);
            var actual = repository.SeeNextClaim();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimsRepository_HandleNextClaim()
        {
            var repository = new ClaimsRepository();
            var expected = new Claim();
            repository.Add(expected);
            var actual = repository.HandleNextClaim();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimsRepository_GetAll_AreEqual()
        {
            var expected = new Claim[]
            {
                new Claim(),
                new Claim(),
                new Claim()
            };

            var repository = new ClaimsRepository();
            foreach (var claim in expected)
            {
                repository.Add(claim);
            }
            List<Claim> actual = repository.GetAll().ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
