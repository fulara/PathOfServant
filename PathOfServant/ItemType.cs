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
        Map,
        DivCard,
    }

    public static class ItemTypeExt
    {
        public static String AsString(this ItemType type)
        {
            switch (type)
            {
                case ItemType.Empty:
                    return "E";
                case ItemType.Unknown:
                    return "U";
                case ItemType.Currency:
                    return "C";
                case ItemType.DivCard:
                    return "D";
                case ItemType.Map:
                    return "M";
            }

            throw new Exception("srsly c#?");
        }
    }
}
