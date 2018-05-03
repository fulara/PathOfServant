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
        public static int HowManySets(Dictionary<ItemType, List<StashItemsFiltered>> itemsPerType)
        {
            //74
            Dictionary<ItemType, int> itemsQty = CountItemTypes(itemsPerType);
            ItemType smallestCountType = itemsQty.OrderBy(i => i.Value).First().Key;
            return itemsQty[smallestCountType];
        }

        public static List<StashItemsFiltered> MakeSets(Dictionary<ItemType, List<StashItemsFiltered>> itemsPerType)
        {
            List<StashItemsFiltered> result = new List<StashItemsFiltered>();
            bool lowLvl = true;
            foreach (var itemTypeEntry in itemsPerType)
            {
                StashItemsFiltered newItem = RemoveItem(itemsPerType, itemTypeEntry.Key, lowLvl);
                result.Add(newItem);// (newItem.category+" iLvl:"+newItem.itlvl + " id:" + newItem.id);

                if (newItem.category== ItemType.Ring)
                {
                    StashItemsFiltered secondRing = RemoveItem(itemsPerType, itemTypeEntry.Key, lowLvl);
                    result.Add(secondRing); //(secondRing.category + " iLvl:" + newItem.itlvl + " id:" + secondRing.id);
                }

                if (newItem.category == ItemType.Wep1h)
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

        public static StashItemsFiltered RemoveItem(Dictionary<ItemType, List<StashItemsFiltered>> items, ItemType type, bool lowLvl)
        {
            StashItemsFiltered thisItem = null;
            if (!type.IsWeapon())
            {
                thisItem=chooseItem(items[type], lowLvl);
            }
            else
            {
                List<StashItemsFiltered> weapons2h = items[ItemType.Wep2h].Where(i => i.category == ItemType.Wep2h).ToList();
                List<StashItemsFiltered> weapons1h = items[ItemType.Wep1h].Where(i => i.category == ItemType.Wep1h).ToList();
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

        public static Dictionary<ItemType, int> CountItemTypes(Dictionary<ItemType, List<StashItemsFiltered>> itemsPerType)
        {
            Dictionary<ItemType, int> itemsQty = new Dictionary<ItemType, int>();
            int h1 = 0;
            int h2 = 0;
            foreach (var itemEntry in itemsPerType)
            {

                if ( itemEntry.Key.IsWeapon() && !(itemEntry.Key == ItemType.Ring))
                {
                    itemsQty.Add(itemEntry.Key, itemEntry.Value.Count);
                }
                else
                {
                    if (itemEntry.Key.IsWeapon())
                    {
                        foreach (var item in itemEntry.Value)
                        {
                            if (item.category == ItemType.Wep1h) h1++;
                            if (item.category == ItemType.Wep2h) h2++;
                        }
                    }
                    if (itemEntry.Key == ItemType.Ring)
                    {
                        itemsQty.Add(itemEntry.Key, itemEntry.Value.Count/2);
                    }
                }
            }

            itemsQty.Add(ItemType.Wep2h, h2 + h1 / 2);
            return itemsQty;
        }
    }
}
