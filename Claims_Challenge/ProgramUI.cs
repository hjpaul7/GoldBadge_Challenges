using Claims_Repo;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Claim = Claims_Repo.Claim;

namespace Claims_Console
{
    public class ProgramUI
    {
        private bool _isRunning = true;

        // New repo
        private readonly ClaimRepository _claimRepo = new ClaimRepository();

        // Start program
        public void Start()
        {
            ClaimList();
            RunMenu();
        }

        // Keep app running
        private void RunMenu()
        {
            while (_isRunning)
            {
                Console.Clear();
                //string userInput = GetMenuSelection();
                //OpenMenuItem(userInput);
                Console.WriteLine(
                "Komodo Claims Dept\n" +
                "1. See all claims\n" +
                "2. Take care of next claim\n" +
                "3. Enter a new claim\n" +
                "4. Modify an existing claim\n" +
                "5. Exit\n");

                Console.Write("Enter a #: ");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        DisplayAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        CreateClaim();
                        break;
                    case "4":
                        UpdateExistingClaim();
                        break;
                    case "5":
                        _isRunning = false;
                        return;
                    default:
                        return;
                }
                Console.WriteLine("Press a key to return");
                Console.ReadKey();
            }
        }

        // Display all claims
        private void DisplayAllClaims()
        {
            Console.Clear();
            Queue<Claim> claimList = _claimRepo.GetClaimList();
            foreach(Claim claim in claimList)
            {
                DisplayClaim(claim);
            }
           
        }

        // Displaying claim
        private void DisplayClaim(Claim claim)
        {
            Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                $"Type: {claim.TypeOfClaim}\n" +
                $"Description: {claim.Description}\n" +
                $"Amount: {claim.ClaimAmount}\n" +
                $"Date of Accident: {claim.DateOfIncident}\n" +
                $"Date of Claim: {claim.DateOfClaim}\n" +
                $"Is the claim valid: {claim.IsValid}\n");

           
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Queue<Claim> claimQueue = _claimRepo.GetClaimList();
            bool nextClaimBool = true;
            while (nextClaimBool)
            {
                if (claimQueue.Count > 0)
                {
                    var next = claimQueue.Peek();
                    DisplayClaim(next);
                }
                Console.WriteLine("Do you want to deal with this claim now (y/n):");
                string userInput = Console.ReadLine();
                if (userInput == "y")
                {
                    claimQueue.Dequeue();
                }
                else if (userInput == "n")
                {
                    nextClaimBool = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }
            }
        }

        // Create new claim
        private void CreateClaim()
        {
            Console.Clear();
            Console.Write("Enter Claim ID: ");
                int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Claim Type: ");
            ClaimType claimType = GetClaimTypes();
            

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Amount: ");
            double amount = double.Parse(Console.ReadLine());

            //Console.Write("Date of Accident: ");
            //DateTime dateOfAccident = DateTime.Parse(Console.ReadLine());

            Console.Write("Date of Accident: ");
            string accidentInput = Console.ReadLine();
            DateTime dateOfAccident = Convert.ToDateTime(accidentInput);

            //Console.Write("Date of Claim: ");
            //DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.Write("Date of Claim: ");
            string claimDateInput = Console.ReadLine();
            DateTime dateOfClaim = Convert.ToDateTime(claimDateInput);

            Claim newClaim = new Claim(id, claimType, description, amount, dateOfAccident, dateOfClaim);
            _claimRepo.AddClaimToList(newClaim);
        }

        private ClaimType GetClaimTypes()
        {
            Console.WriteLine("Select a Claim Type:\n" +
                "1. Home\n" +
                "2. Car\n" +
                "3. Theft\n");

            while (true)
            {
                switch(Console.ReadLine())
                {
                    case "1":
                        return ClaimType.Home;

                    case "2":
                        return ClaimType.Car;

                    case "3":
                        return ClaimType.Theft;
                }
                Console.WriteLine("Invalid Selection");
            }
        }

        // Update
        private void UpdateExistingClaim()
        {
            Console.Clear();
            // Display all claims
            DisplayAllClaims();

            // ask for id of claim
            Console.Write("Enter the Claim ID to update: ");

            // get claim
            int oldClaim = Convert.ToInt32(Console.ReadLine());

            // build a new object

            Console.Write("Enter Claim ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Claim Type: ");
            ClaimType claimType = GetClaimTypes();


            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Amount: ");
            double amount = double.Parse(Console.ReadLine());

            //Console.Write("Date of Accident: ");
            //DateTime dateOfAccident = DateTime.Parse(Console.ReadLine());

            Console.Write("Date of Accident: ");
            string accidentInput = Console.ReadLine();
            DateTime dateOfAccident = Convert.ToDateTime(accidentInput);

            //Console.Write("Date of Claim: ");
            //DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.Write("Date of Claim: ");
            string claimDateInput = Console.ReadLine();
            DateTime dateOfClaim = Convert.ToDateTime(claimDateInput);

            Claim newClaim = new Claim(id, claimType, description, amount, dateOfAccident, dateOfClaim);


            // Verify
            bool wasUpdated = _claimRepo.UpdateExisitingClaim(oldClaim, newClaim);

            if (wasUpdated)
            {
                Console.WriteLine("Claim updated");
            }
            else
            {
                Console.WriteLine("Could not update claim");
            }

        }

        // Prepopulated list
        private void ClaimList()
        {
            Claim claim1 = new Claim(1, ClaimType.Car, "Fender Bender", 5000, new DateTime(2020, 7, 11), new DateTime(2020, 7, 13));
            Claim claim2 = new Claim(2, ClaimType.Theft, "Break in", 2000, new DateTime(2020, 1, 1), new DateTime(2020, 1, 2));
            Claim claim3 = new Claim(3, ClaimType.Home, "Fire", 10000, new DateTime(2020, 2, 12), new DateTime(2020, 2, 13));

            _claimRepo.AddClaimToList(claim1);
            _claimRepo.AddClaimToList(claim2);
            _claimRepo.AddClaimToList(claim3);
        }


        // ---------- ORIGINAL WAY ------------

        //private string GetMenuSelection()
        //{
        //    Console.Clear();
        //    Console.WriteLine(
        //        "Komodo Claims Dept\n" +
        //        "1. See all claims\n" +
        //        "2. Take care of next claim\n" +
        //        "3. Enter a new claim\n" +
        //        "4. Modify an existing claim\n" +
        //        "5. Find claim by ID\n" +
        //        "6. Exit\n");

        //    Console.Write("Enter a #: ");
        //    string userInput = Console.ReadLine();

        //    switch (userInput)
        //    {
        //        case "1":
        //            DisplayAllClaims();
        //            break;
        //        case "2":
        //            // next claim
        //            break;
        //        case "3":
        //            CreateClaim();
        //            break;
        //        case "4":
        //            UpdateExistingClaim();
        //            break;
        //        case "5":
        //            FindClaimByID();
        //            break;
        //        case "6":
        //            _isRunning = false;
        //            return;
        //        default:
        //            return;
        //    }
        //    //return userInput;
        //}

        // Menu selection

        // Menu items switch
        //private void OpenMenuItem(string userInput)
        //{
        //    Console.Clear();
        //    switch (userInput)
        //    {
        //        case "1":
        //            DisplayAllClaims();
        //            break;
        //        case "2":
        //            // next claim
        //            break;
        //        case "3":
        //            CreateClaim();
        //            break;
        //        case "4":
        //            UpdateExistingClaim();
        //            break;
        //        case "5":
        //            FindClaimByID();
        //            break;
        //        case "6":
        //            _isRunning = false;
        //            return;
        //        default:
        //            return;
        //    }
        //}

        // Find claim by ID
        //private void FindClaimByID()
        //{
        //    Console.Clear();
        //    Console.Write("Enter Claim ID: ");
        //    int claimID = Convert.ToInt32(Console.ReadLine());

        //    Claim searchResult = _claimRepo.GetClaimByID(claimID);

        //    if (searchResult != null)
        //    {
        //        DisplayClaim(searchResult);
        //    }
        //    else
        //    {
        //        Console.WriteLine("That claim was not found");
        //    }
        //}
    }
}
