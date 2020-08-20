using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repo
{
    public class Badge_Repository
    {
        public Dictionary<int, List<string>> _badgeList = new Dictionary<int, List<string>>();

        // Create badge
        //public void AddBadge(Badge badge)
        //{
        //    doorAccess.Add(badge.BadgeID, badge.ListOfDoors);
        //}

        // Read all badges
        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgeList;
        }

        // Create badge
        public void CreateBadge(int badgeID)
        {
            List<string> listOfDoors = new List<string>();
            Badge newBadge = new Badge(badgeID, listOfDoors);

            _badgeList.Add(newBadge.BadgeID, newBadge.ListOfDoors);
        }

        // Add door to badge
        public void AddDoorToBadge(int badgeID, string door)
        {
            _badgeList[badgeID].Add(door);
        }

        // Delete all doors from badge
        public void DeleteAllDoorsFromBadge(int badgeID)
        {
            _badgeList[badgeID].Clear();
        }


































        // Read Dictionary
        //public Dictionary<int, List<string>> GetBadges()
        //{
        //    return doorAccess;
        //}

        //// Read by Badge ID
        //public Badge GetBadgeByID(int id)
        //{
        //    for (int index = 0; index < doorAccess.Count; index++)
        //    {
        //        var item = doorAccess.ElementAt(index);
        //        if (item.Key == id)
        //        {
        //            Badge badge = new Badge(item.Key, item.Value);
        //            return badge;
        //        }
        //    }
        //    return null;
        //}

        //// Update Badge
        //public void BadgeUpdate(int id, Badge newBadge)
        //{
        //    for (int index = 0; index < doorAccess.Count; index++)
        //    {
        //        var item = doorAccess.ElementAt(index);
        //        if (item.Key == newBadge.BadgeID)
        //        {
        //            item.Key = newBadge.BadgeID;
        //            item.Value = newBadge.ListOfDoors;
        //        }
        //    }
        //}

        // Delete Badge
        //public void BadgeDelete(Badge newBadge)
        //{
        //    doorAccess.Remove(newBadge.BadgeID);
        //}

        // Delete Doors from Badge

    }
}
