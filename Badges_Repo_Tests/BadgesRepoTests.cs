using System;
using System.Collections.Generic;
using Badges_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Badges_Repo_Tests
{
    [TestClass]
    public class BadgesRepoTests
    {
        private Badge_Repository _repo = new Badge_Repository();
        private Badge _content = new Badge();


        [TestInitialize]
        public void SeedBadges()
        {
            _repo.CreateBadge(1);
            _repo.AddDoorToBadge(1, "A1");
        }

        // Create and Read
        //  - Create Badge
        //  - Read badge
        //  - Add door to badge
        //  - Read door on badge
        // ---------- uhhhh doesn't work, i really couldn't figure it out -----------
        [TestMethod]
        public void CreateBadge_AndShouldReturnReadBadge()
        {
            _repo.CreateBadge(1);
            _repo.AddDoorToBadge(1, "A1");

            // Act - Read
            List<string> directory = _repo.GetAllBadges();

            bool directoryHasNewBadge = directory.Contains();

            // Assert
            Assert.IsTrue(directoryHasNewBadge);
        }

        [TestMethod]
        public void DisplayAllBadges_ShouldDisplayAllBadges()
        {
            _repo.GetAllBadges();
        }

        // Delete single door
        // also doesn't work, couldn't figure it out
        [TestMethod]
        public void DeleteExistingItem_ShouldReturnTrue(int id, bool expectedResult)
        {
            bool updateBadge = _repo.DeleteBadgeDoor(id, "A1");
            Assert.AreEqual(expectedResult, updateBadge);
        }

        // Delete all doors
        // again couldn't figure this out
        [TestMethod]
        public void DeleteAllExistingItems_ShouldReturnTrue(int id, bool expectedResult)
        {
            bool updateBadgeDeleteAllDoors = _repo.DeleteAllDoorsFromBadge(id);
            Assert.AreEqual(expectedResult, updateBadgeDeleteAllDoors);
        }

        [TestMethod]
        public void DoesDictionaryHaveKey_ShouldReturnTrue(int badgeID, bool expectedResult)
        {
            bool doesDictionaryHaveKey = _repo.HasKey(badgeID);
            Assert.AreEqual(expectedResult, doesDictionaryHaveKey);
        }

        // couldn't figure this out either
        [TestMethod]
        public void GetBadgeByID_ShouldReturnTrue()
        {

        }


    }
}
