using System;
using Badges_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Badges_Repo_Tests
{
    [TestClass]
    public class BadgesRepoTests
    {
        public Badge_Repository _badgeRepo = new Badge_Repository();


        [TestInitialize]
        public void BadgeInitialize()
        {
            _badgeRepo.CreateBadge(1);
        }


        [TestMethod]
        public void CreateBadge_AndShouldReturnReadBadge()
        {

        }

        [TestMethod]
        public void DisplayAllBadges_ShouldDisplayAllBadges()
        {
            _badgeRepo.GetAllBadges();
        }
    }
}
