using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathOfServant
{
    public class StashItemsFiltered
    {
        public ItemType category { get; set; }
        public string subCategory { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public Int32 itlvl { get; set; }
        public string typeName { get; set; }
        public Int32 x { get; set; }
        public Int32 y { get; set; }
        public Int32 w { get; set; }
        public Int32 h { get; set; }
        public bool quadLayout { get; set; }
        public bool picked { get; set; }
        public bool identified { get; set; }
        public int frameType { get; set; }
        public int inventoryIndex { get; set; }

        public static StashItemsFiltered Copy(StashItemsFiltered inputItem)
        {
            StashItemsFiltered result = new StashItemsFiltered();

            result.category = inputItem.category;
            result.subCategory = inputItem.subCategory;
            result.icon = inputItem.icon;
            result.id = inputItem.id;
            result.itlvl = inputItem.itlvl;
            result.typeName = inputItem.typeName;
            result.x = inputItem.x;
            result.y = inputItem.y;
            result.w = inputItem.w;
            result.h = inputItem.h;
            result.quadLayout = inputItem.quadLayout;
            result.picked = inputItem.picked;
            result.identified = inputItem.identified;
            result.frameType = inputItem.frameType;
            result.inventoryIndex = inputItem.inventoryIndex;
            return result;
        }
    }

    public class PrivateStash
    {
        public bool quadLayout { get; set; }
        public List<object> items { get; set; }
    }

    public class Stash
    {
        public string accountName { get; set; }
        public string lastCharacterName { get; set; }
        public string id { get; set; }
        public string stash { get; set; }
        public string stashType { get; set; }
        public List<object> items { get; set; }
        public bool @public { get; set; }
    }

    public class RootObject
    {
        public string next_change_id { get; set; }
        public List<Stash> stashes { get; set; }
    }
}
