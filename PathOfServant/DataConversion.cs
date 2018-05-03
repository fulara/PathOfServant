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
        public static Dictionary<ItemType, List<StashItemsFiltered>> SortItemsToCategories(List<StashItemsFiltered> items)
        {
            return items.GroupBy(i => i.category).ToDictionary(i => i.Key, i => i.ToList());
        }
    }
}
