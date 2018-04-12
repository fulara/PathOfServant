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
        public Dictionary<ItemType, int> offsets = new Dictionary<ItemType, int>();

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

        public void UpdateOffsets(TabIndices indices)
        {
            offsets[ItemType.Currency] = indices.CurrenciesIndex  - 1;
            offsets[ItemType.Map] =  indices.MapIndex - 1;
            offsets[ItemType.DivCard] = indices.DivinationCardIndex - 1;
            offsets[ItemType.Fragment] = indices.FragmentIndex - 1;
            offsets[ItemType.Essence] = indices.EssencesIndex - 1;
        }
    }
    
}
