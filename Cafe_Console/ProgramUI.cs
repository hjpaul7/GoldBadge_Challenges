using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    class ProgramUI
    {
        private bool _isRunning = true;

        private readonly CafeContentRepository _cafeRepo = new CafeContentRepository();

        public void Start()
        {
            MenuList();
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }

        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine(
                "Welcome to the Cafe Manager App\n" +
                "1. View full menu\n" +
                "2. Find your meal by name\n" +
                "3. Add a new meal\n" +
                "4. Remove a meal\n" +
                "5. Exit\n");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    DisplayFullMenu();
                    break;
                case "2":
                    FindMealByName();
                    break;
                case "3":
                    CreateMeal();
                    break;
                case "4":
                    DeleteMeal();
                    break;
                case "5":
                    _isRunning = false;
                    return;
                default:
                    return;
            }
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
        }

        private void DisplayFullMenu()
        {
            List<CafeContent> menuList = _cafeRepo.GetMenuList();
            foreach (CafeContent meal in menuList)
            {
                DisplayMenu(meal);
            }
        }

        private void DisplayMenu(CafeContent meal)
        {
            Console.WriteLine($"Number: {meal.Number}\n" +
                $"Name: {meal.Name}\n" +
                $"Description: {meal.Description}\n" +
                $"Ingredients: {meal.Ingredients}\n" +
                $"Price: {meal.Price}\n");
        }

        // Find meal by name
        private void FindMealByName()
        {
            Console.WriteLine("What's the meal name?");
            string name = Console.ReadLine();

            CafeContent searchResult = _cafeRepo.GetMealByName(name);

            if (searchResult != null)
            {
                DisplayMenu(searchResult);
            }
            else
            {
                Console.WriteLine("Meal not found");
            }
        }

        // Add new content
        private void CreateMeal()
        {
            Console.Write("Enter meal #: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            Console.Write("Enter ingredients: ");
            string ingredients = Console.ReadLine();

            Console.Write("Enter price: ");
            string price = Console.ReadLine();

            CafeContent newMeal = new CafeContent(number, name, description, ingredients, price);
            _cafeRepo.AddMeal(newMeal);
        }

        private void DeleteMeal()
        {
            DisplayFullMenu();
            Console.Write("Meal name you want deleted: ");
            string userInput = Console.ReadLine();
            bool wasDeleted = _cafeRepo.DeleteMealFromMenu(userInput);
            if (wasDeleted)
            {
                Console.WriteLine("Your meal was deleted\n");
            }
            else
            {
                Console.WriteLine("Menu meal wasn't deleted\n");
            }
        }

        private void MenuList()
        {
            CafeContent pbj = new CafeContent(1, "PBJ", "Peanut Butter Jelly", "Peanut Butter, Jelly, Bread", "5");
            CafeContent hamCheese = new CafeContent(2, "Ham and Cheese", "Hot Ham with melted cheese", "Smoked Ham, Swiss Cheese, White Bread", "7");
            CafeContent turkeySwiss = new CafeContent(3, "Turkey and Swiss", "Smoked Turkey with Swiss", "Smoked Turkey, Swiss Cheese, White Bread", "7");

            _cafeRepo.AddMeal(pbj);
            _cafeRepo.AddMeal(hamCheese);
            _cafeRepo.AddMeal(turkeySwiss);
        }
    }
}
