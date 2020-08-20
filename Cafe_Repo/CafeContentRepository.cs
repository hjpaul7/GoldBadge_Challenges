using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repo
{
    public class CafeContentRepository
    {
        // Field
        private List<CafeContent> _menuList = new List<CafeContent>();

        // Create
        public void AddMeal(CafeContent meal)
        {
            _menuList.Add(meal);
        }

        // Read
        public List<CafeContent> GetMenuList()
        {
            return _menuList;
        }

        // Delete
        public bool DeleteMealFromMenu(string name)
        {
            CafeContent meal = GetMealByName(name);

            if (meal == null)
            {
                return false;
            }
            int initialCount = _menuList.Count;
            _menuList.Remove(meal);

            if (initialCount > _menuList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Helper
        public CafeContent GetMealByName(string name)
        {
            foreach (CafeContent meal in _menuList)
            {
                if (meal.Name == name)
                {
                    return meal;
                }
            }
            return null;
        }
    }
}
