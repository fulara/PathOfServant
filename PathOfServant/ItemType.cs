using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathOfServant
{
    public enum ItemType
    {
        Empty,
        Unknown,
        Currency,
        Essence,
        Map,
        Fragment,
        DivCard,
    }

    public static class ItemTypeExt
    {
        public static String AsString(this ItemType type)
        {
            switch (type)
            {
                case ItemType.Empty:
                    return "e";
                case ItemType.Unknown:
                    return "U";
                case ItemType.Currency:
                    return "C";
                case ItemType.DivCard:
                    return "D";
                case ItemType.Fragment:
                    return "F";
                case ItemType.Essence:
                    return "F";
                case ItemType.Map:
                    return "M";
            }

            throw new Exception("srsly c#?");
        }
    }
}
