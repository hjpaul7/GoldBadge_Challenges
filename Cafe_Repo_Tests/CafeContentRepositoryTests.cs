using System;
using System.Collections.Generic;
using Cafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeContentRepositoryTests
{
    [TestClass]
    public class CafeContentRepositoryTests
    {
        private CafeContentRepository _repo;
        private CafeContent _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new CafeContentRepository();
            _content = new CafeContent(6, "Burger", "Sick Burger", "Bun, patty, onion", "7");

            _repo.AddMeal(_content);
        }

        // Create AND Read

        [TestMethod]
        public void GetMenu_ReturnCollection()
        {
            CafeContentRepository repo = new CafeContentRepository();
            CafeContent newContent = new CafeContent(6, "Burger", "Sick Burger", "Bun, patty, onion", "7");

            repo.AddMeal(newContent);

            // Act
            List<CafeContent> directory = repo.GetMenuList();

            bool directoryHasNewContent = directory.Contains(newContent);

            // Assert
            Assert.IsTrue(directoryHasNewContent);
        }

        // Delete

        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            Arrange();

            bool removeResult = _repo.DeleteMealFromMenu("Burger");

            Assert.IsTrue(removeResult);
        }
    }
}
