using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathOfServant
{
    public class TabOffset
    {
        Dictionary<ItemType, int> offsets = new Dictionary<ItemType, int>
        {
            { ItemType.Currency, 2},
            { ItemType.Map, 1},
            { ItemType.DivCard, 5},
            { ItemType.Fragments, 3},
        };

        public int GetOffset(ItemType type)
        {
            if(offsets.ContainsKey(type))
            {
                return offsets[type];
            }

            return 0;
        }
    }
}
