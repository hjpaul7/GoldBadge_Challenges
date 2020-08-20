using System;
using System.Collections.Generic;
using Claims_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Claims_Repo_Tests
{
    [TestClass]
    public class ClaimsTests
    {
        //private ClaimRepository _claimRepo = new ClaimRepository();
        //private Claim _claim;
        private ClaimRepository _repo;
        private Claim _content;


        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
            _content = new Claim(5, ClaimType.Car, "Test", 2000, new DateTime(2020, 2, 2), new DateTime(2020, 2, 3));

            _repo.AddClaimToList(_content);
        }


        //Create AND Read

       [TestMethod]
        public void GetDirectory_ShouldReturnCollection()
        {
            // Arrange - Create
            ClaimRepository repo = new ClaimRepository();
            Claim newClaim = new Claim(5, ClaimType.Car, "Test", 2000, new DateTime(2020, 2, 2), new DateTime(2020, 2, 3));

            repo.AddClaimToList(newClaim);

            // Act - Read
            Queue<Claim> directory = repo.GetClaimList();

            bool directoryHasNewClaim = directory.Contains(newClaim);

            // Assert
            Assert.IsTrue(directoryHasNewClaim);
        }




        // Update AND Helper (Find by ID)

        [DataTestMethod]
        [DataRow(5, true)]
        public void UpdateExistingItem_ShouldReturnTrue(int id, bool expectedResult)
        {
            bool updateClaim = _repo.UpdateExisitingClaim(id, _content);
            Assert.AreEqual(expectedResult, updateClaim);
        }























        //private void Seed()
        //{
        //    Claim claim1 = new Claim(1, ClaimType.Car, "Fender Bender", 5000, new DateTime(2020, 7, 11), new DateTime(2020, 7, 13));
        //    Claim claim2 = new Claim(2, ClaimType.Theft, "Break in", 2000, new DateTime(2020, 1, 1), new DateTime(2020, 1, 2));
        //    Claim claim3 = new Claim(3, ClaimType.Home, "Fire", 10000, new DateTime(2020, 2, 12), new DateTime(2020, 2, 13));

        //    _claimRepo.AddClaimToList(claim1);
        //    _claimRepo.AddClaimToList(claim2);
        //    _claimRepo.AddClaimToList(claim3);
        //}

    }
}
