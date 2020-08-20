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
                        // add badge
                        break;

                    case "2":
                        // edit badge
                        break;

                    case "3":
                        // list all badges
                        break;

                    case "4":
                        _isRunning = false;
                        break;

                    default:
                        return;
                }
            }
        }
    }
}
