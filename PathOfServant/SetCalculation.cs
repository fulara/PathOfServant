using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Dictionary<ItemType, int> itemsQty = CountItemTypes(itemsPerType);
            ItemType smallestCountType = itemsQty.OrderBy(i => i.Value).First().Key;
            return itemsQty[smallestCountType];
        }

        public static List<StashItemsFiltered> MakeSets(Dictionary<ItemType, List<StashItemsFiltered>> itemsPerType)
        {
            List<StashItemsFiltered> result = new List<StashItemsFiltered>();
            bool needLowLvl = true;
            bool weaponsChoosen = false;
            foreach (var itemTypeEntry in itemsPerType)
            {
                
                if (itemTypeEntry.Key.ToString() != "Wep1h" && itemTypeEntry.Key.ToString() != "Wep2h")
                {
                    StashItemsFiltered newItem = RemoveItem(itemsPerType, itemTypeEntry.Key, ref needLowLvl);
                    result.Add(newItem);// (newItem.category+" iLvl:"+newItem.itlvl + " id:" + newItem.id);

                    if (newItem.category == ItemType.Ring)
                    {
                        StashItemsFiltered secondRing = RemoveItem(itemsPerType, itemTypeEntry.Key,ref  needLowLvl);
                        result.Add(secondRing); //(secondRing.category + " iLvl:" + newItem.itlvl + " id:" + secondRing.id);
                    }
                }
                else
                {
                    if (weaponsChoosen) continue;
                    StashItemsFiltered wep = RemoveItem(itemsPerType, itemTypeEntry.Key, ref needLowLvl);
                    result.Add(wep);
                    if (wep.typeName == "Wep1h")
                    {
                        StashItemsFiltered wep2nd = RemoveItem(itemsPerType, itemTypeEntry.Key,ref needLowLvl);
                        result.Add(wep2nd);
                    }
                    weaponsChoosen = true;
                }
            }
            return result;
        }

        public static StashItemsFiltered RemoveItem(Dictionary<ItemType, List<StashItemsFiltered>> items, ItemType type, ref bool needLowLvl)
        {
            bool temp = needLowLvl;
            StashItemsFiltered thisItem = null;
            if (!type.IsWeapon())
            {
                thisItem = ChooseItem(items[type], ref needLowLvl);
            }
            else
            {
                List<StashItemsFiltered> weapons2h = items[ItemType.Wep2h].Where(i => i.category == ItemType.Wep2h).ToList();
                List<StashItemsFiltered> weapons1h = items[ItemType.Wep1h].Where(i => i.category == ItemType.Wep1h).ToList();
                if (weapons2h.Count > 0)
                {
                    thisItem = ChooseItem(weapons2h, ref needLowLvl);
                }
                else
                {
                    thisItem = ChooseItem(weapons1h, ref needLowLvl);
                }
            }
            items[type].Remove(thisItem);

            return thisItem;
        }

        public static StashItemsFiltered ChooseItem(List<StashItemsFiltered> items, ref bool needLowLvl)
        {
            Debug.Write("need low: "+needLowLvl +" ");
            StashItemsFiltered result = null;
            if (needLowLvl)
            {
                foreach (var item in items)
                {
                    if (item.picked) continue;
                    if (item.identified) continue;
                    if (item.frameType != 2) continue;
                    if (item.itlvl < 75)
                    {
                        result = item;
                        needLowLvl = false;
                        break;
                    }
                }
            }
            else
            {
                foreach (var item in items)
                {
                    if (item.picked) continue;
                    if (item.identified) continue;
                    if (item.frameType != 2) continue;
                    if (item.itlvl > 74)
                    {
                        result = item;
                        break;
                    }
                }
            }
            if (result==null)
            {
                foreach (var item in items)
                {
                    if (item.picked) continue;
                    if (item.identified) continue;
                    if (item.frameType != 2) continue;
                    result = item;
                    break;
                }
            }
            Debug.Write(result.typeName + " " + result.itlvl + Environment.NewLine);
            return result;
        }

        

        public static Dictionary<ItemType, int> CountItemTypes(Dictionary<ItemType, List<StashItemsFiltered>> itemsPerType)
        {
            Dictionary<ItemType, int> itemsQty = new Dictionary<ItemType, int>();
            int h1 = 0;
            int h2 = 0;
            foreach (var itemEntry in itemsPerType)
            {

                if ( !itemEntry.Key.IsWeapon() && !(itemEntry.Key == ItemType.Ring))
                {

                    itemsQty.Add(itemEntry.Key, itemEntry.Value.Where(i => !i.picked  & !i.identified & i.frameType==2).ToList().Count);
                }
                else
                {
                    if (itemEntry.Key.IsWeapon())
                    {
                        foreach (var item in itemEntry.Value)
                        {
                            if (item.picked) continue;
                            if (item.identified) continue;
                            if (item.frameType != 2) continue;
                            if (item.category == ItemType.Wep1h) h1++;
                            if (item.category == ItemType.Wep2h) h2++;
                        }
                    }
                    if (itemEntry.Key == ItemType.Ring)
                    {
                        itemsQty.Add(itemEntry.Key, itemEntry.Value.Where(i => i.picked == false).ToList().Count / 2);
                    }
                }
            }

            itemsQty.Add(ItemType.Wep2h, h2 + h1 / 2);
            return itemsQty;
        }
    }
}
