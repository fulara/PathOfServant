using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PathOfServant.Form1;

namespace PathOfServant
{
    class SetCalculation
    {
        public static int HowManySets(Dictionary<string, List<StashItemsFiltered>> itemsPerType)
        {
            //74
            Dictionary<string, int> itemsQty = CountItemTypes(itemsPerType);
            string smallestCountType = itemsQty.OrderBy(i => i.Value).First().Key;
            return itemsQty[smallestCountType];
        }

        public static List<StashItemsFiltered> MakeSets(Dictionary<string, List<StashItemsFiltered>> itemsPerType)
        {
            List<StashItemsFiltered> result = new List<StashItemsFiltered>();
            bool lowLvl = true;
            foreach (var itemTypeEntry in itemsPerType)
            {
                StashItemsFiltered newItem = RemoveItem(itemsPerType, itemTypeEntry.Key, lowLvl);
                result.Add(newItem);// (newItem.category+" iLvl:"+newItem.itlvl + " id:" + newItem.id);

                if (newItem.category=="ring")
                {
                    StashItemsFiltered secondRing = RemoveItem(itemsPerType, itemTypeEntry.Key, lowLvl);
                    result.Add(secondRing); //(secondRing.category + " iLvl:" + newItem.itlvl + " id:" + secondRing.id);
                }

                if (newItem.category == "weapon1h")
                {
                    StashItemsFiltered secondWeapon1h = RemoveItem(itemsPerType, itemTypeEntry.Key, lowLvl);
                    result.Add(secondWeapon1h);//(secondWeapon1h.category + " iLvl:" + newItem.itlvl + " id:" + secondWeapon1h.id);
                }
            }
            return result;
        }

        public static StashItemsFiltered chooseItem(List<StashItemsFiltered> items, bool lowLvl)
        {
            StashItemsFiltered result = null;
            foreach (var item in items)
            {
                if (lowLvl)
                {
                    if (item.itlvl < 75)
                    {
                        result = item;
                        lowLvl = false;
                    }
                }
                else
                {
                    if (item.itlvl > 74)
                    {
                        result = item;
                    }
                }
            }
            if (result == null)
            {
                result = items[0];
            }

            return result;
        }

        public static StashItemsFiltered RemoveItem(Dictionary<string, List<StashItemsFiltered>> items, string type, bool lowLvl)
        {
            StashItemsFiltered thisItem = null;
            if (type != "weapon")
            {
                thisItem=chooseItem(items[type], lowLvl);
            }
            else
            {
                List<StashItemsFiltered> weapons2h = items["weapon"].Where(i => i.category == "weapon2h").ToList();
                List<StashItemsFiltered> weapons1h = items["weapon"].Where(i => i.category == "weapon1h").ToList();
                if (weapons2h.Count>0)
                {
                    thisItem = chooseItem(weapons2h, lowLvl);
                }
                else
                {
                    thisItem = chooseItem(weapons1h, lowLvl);
                }
            }
            items[type].Remove(thisItem);
            return thisItem;
        }

        public static Dictionary<string, int> CountItemTypes(Dictionary<string, List<StashItemsFiltered>> itemsPerType)
        {
            Dictionary<string, int> itemsQty = new Dictionary<string, int>();
            int h1 = 0;
            int h2 = 0;
            foreach (var itemEntry in itemsPerType)
            {

                if (!itemEntry.Key.Contains("weapon") & !itemEntry.Key.Contains("ring"))
                {
                    itemsQty.Add(itemEntry.Key, itemEntry.Value.Count);
                }
                else
                {
                    if (itemEntry.Key.Contains("weapon"))
                    {
                        foreach (var item in itemEntry.Value)
                        {
                            if (item.category == "weapon1h") h1++;
                            if (item.category == "weapon2h") h2++;
                        }
                    }
                    if (itemEntry.Key == "ring")
                    {
                        itemsQty.Add(itemEntry.Key, itemEntry.Value.Count/2);
                    }
                }
            }

            itemsQty.Add("weapon", h2 + h1 / 2);
            return itemsQty;
        }
    }
}
