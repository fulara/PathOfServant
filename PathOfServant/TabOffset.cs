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
        public static Dictionary<ItemType, int> offsets = new Dictionary<ItemType, int>
        {
            { ItemType.Currency, 1},
            { ItemType.Map, 1},
            { ItemType.DivCard, 1},
            { ItemType.Fragments, 1},
        };

        public int CurrOffset { get; }
        public int MapOffset { get; }
        public int DvOffset { get; }
        public int FragOffset { get; }

        public int GetOffset(ItemType type)
        {
            if (offsets.ContainsKey(type))
            {
                int i = offsets[type];
                return offsets[type];
            }

            return 0;
        }
    }
    
}
