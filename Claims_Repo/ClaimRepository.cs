using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repo
{
    public class ClaimRepository
    {
        // Field

        private Queue<Claim> _listOfClaims = new Queue<Claim>();

        // Create
        public void AddClaimToList(Claim claim)
        {
            _listOfClaims.Enqueue(claim);
        }

        // Read
        public Queue<Claim> GetClaimList()
        {
            return _listOfClaims;
        }

        // Update
        public bool UpdateExisitingClaim(int originalID, Claim newClaim)
        {
            Claim oldClaim = GetClaimByID(originalID);

            if (oldClaim != null)
            {
                oldClaim.TypeOfClaim = newClaim.TypeOfClaim;
                oldClaim.Description = newClaim.Description;
                oldClaim.ClaimAmount = newClaim.ClaimAmount;
                oldClaim.DateOfIncident = newClaim.DateOfIncident;
                oldClaim.DateOfClaim = newClaim.DateOfClaim;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper
        public Claim GetClaimByID(int claimID)
        {
            foreach (Claim claim in _listOfClaims)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }

        // ---------- EXTRAS ------------

        // Delete
        //public bool RemoveClaimFromList(int claimID)
        //{
        //    Claim claim = GetClaimByID(claimID);

        //    if (claim == null)
        //    {
        //        return false;
        //    }
        //    int initialCount = _listOfClaims.Count;
        //    _listOfClaims.Dequeue();

        //    if(initialCount > _listOfClaims.Count)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        // grab next item in queue, doesn't delete
        //public void NextItem()
        //{
        //    _listOfClaims.Peek();
        //}

    }
}
