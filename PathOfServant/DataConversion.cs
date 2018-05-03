using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PathOfServant.Form1;

namespace PathOfServant
{
    class DataConversion
    {
        public static Dictionary<string, List<StashItemsFiltered>> SortItemsToCategories(Dictionary<string, string> itemData, List<StashItemsFiltered> items)
        {
            Dictionary<string, List<StashItemsFiltered>> result = new Dictionary<string, List<StashItemsFiltered>>();
            foreach (var item in items)
            {
                item.typeName = item.typeName.Replace("Superior ", "");
                string dictCategory = "";
                if (item.category == "weapons")
                {
                    item.category = "weapon";
                    string weaponCat = "";
                    if (!itemData.TryGetValue(item.typeName, out weaponCat))
                    {
                        MessageBox.Show("Unknown item: " + item.typeName);
                        continue;
                    }
                    dictCategory = item.category;
                    item.category = weaponCat;
                    
                }
                else
                {
                    dictCategory = item.subCategory;
                    item.subCategory = item.category;
                    item.category = dictCategory;
                }

                if (!result.ContainsKey(dictCategory))
                {
                    result.Add(dictCategory, new List<StashItemsFiltered>());
                }
                result[dictCategory].Add(item);
                
            }

            return result;
        }
    }
}
