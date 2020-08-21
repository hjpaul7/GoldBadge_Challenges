using Badges_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Console
{
    public class ProgramUI
    {
        private bool _isRunning = true;
        private readonly Badge_Repository _badgeRepo = new Badge_Repository();

        public void Start()
        {
            RunMenu();
        }

        public void RunMenu()
        {
            while (_isRunning)
            {
                Console.Clear();
                Console.WriteLine("1. Add Badge\n" +
                    "2. Edit Badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateBadge();
                        break;

                    case "2":
                        EditBages();
                        break;

                    case "3":
                        DisplayAllBadges();
                        break;

                    case "4":
                        _isRunning = false;
                        break;

                    default:
                        return;
                }
            }
        }

        private void DisplayAllBadges()
        {
            Console.Clear();

            //Console.WriteLine($"{"Badge ID);

            Dictionary<int, List<string>> badgeList = _badgeRepo.GetAllBadges();
            foreach (KeyValuePair<int, List<string>> badge in badgeList)
            {
                int displayBadgeKey = badge.Key;
                foreach (string door in badge.Value)
                {
                    string displayDoor = door;
                    Console.WriteLine(displayBadgeKey);
                    Console.WriteLine(displayDoor);
                }
               
            }
            Console.WriteLine("Press any key to return");
            Console.ReadKey();

        }

        //private void DisplayBadge(Badge badge)
        //{
        //    Console.WriteLine($"Badge ID: {badge.BadgeID}\n" +
        //        $"Doors: {badge.ListOfDoors}");
        //}


        //public void DisplayAllBadges()
        //{
        //    Console.WriteLine($"{"Badge ID", -12}{"Door Access"}");
        //    foreach (KeyValuePair<int, List<string>> badge in _badgeRepo)
        //    {
        //        Console.WriteLine($"{badge.Key, -12}");
        //        string joined = string.Join(", ", badge.Value.ToArray());
        //        Console.WriteLine($"{joined}");
        //    }
        //}

        public void CreateBadge()
        {
            Console.Clear();
            Console.Write("Enter Badge #: ");
            int badgeID = Convert.ToInt32(Console.ReadLine());

            //List<string> newList = new List<string>();
            _badgeRepo.CreateBadge(badgeID);
            AddDoor(badgeID);

            while (_isRunning)
            {
                Console.WriteLine("Do you want to add more doors?\n" +
                    "\n" +
                    "1. Yes\n" +
                    "2. No\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddDoor(badgeID);
                        break;
                    case "2":
                        Console.WriteLine("Press any key to return");
                        RunMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        Console.ReadKey();
                        break;

                }
            }
        }

        public void AddDoor(int badgeID)
        {
            Console.Write("Add door: ");
            string doorInput = Console.ReadLine();

            _badgeRepo.AddDoorToBadge(badgeID, doorInput);
        }

        public void EditBages()
        {
            Console.Clear();
            Console.Write("Enter BadgeID: ");
            int badgeID = Convert.ToInt32(Console.ReadLine());

            if (_badgeRepo.HasKey(badgeID))
            {
                while (_isRunning)
                {
                    Console.WriteLine("1. Add door\n" +
                        "2. Delete door\n" +
                        "3. Delete all doors\n" +
                        "4. Main menu\n");

                    string userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            AddDoor(badgeID);
                            Console.WriteLine("Door Added");
                            Console.ReadKey();
                            break;

                        case "2":
                            Console.WriteLine("Enter Badge ID: ");
                            _badgeRepo.GetBadgeByID(badgeID);

                            Console.WriteLine("Enter door to remove: ");
                            string doorInput = Console.ReadLine();
                            _badgeRepo.DeleteBadgeDoor(badgeID, doorInput);
                            Console.WriteLine("Door Deleted");
                            Console.ReadKey();
                            break;

                        case "3":
                            _badgeRepo.DeleteAllDoorsFromBadge(badgeID);
                            Console.WriteLine("All doors deleted");
                            Console.ReadKey();
                            break;

                        case "4":
                            _isRunning = false;
                            break;

                        default:
                            Console.WriteLine("Invalid Selection");
                            Console.ReadKey();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid Badge");
                Console.ReadKey();
            }
        }


    }
}
