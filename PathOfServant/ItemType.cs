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
        Gem,
        Jewel,

        Body,
        Boots,
        Gloves,
        Ring,
        Amulet,
        Helmet,
        Wep1h,
        Wep2h,
        Shield,
        Belt,
        Flasks,


        BestiaryMonster,
    }

    public static class ItemTypeUtils
    {
        public static ItemType FromString(String s)
        {
            switch (s)
            {
                case "amulet":
                    return ItemType.Amulet;
                case "ring":
                    return ItemType.Ring;
                case "weapon2h":
                    return ItemType.Wep2h;
                case "weapon1h":
                    return ItemType.Wep1h;
                case "chest":
                    return ItemType.Body;
                case "boots":
                    return ItemType.Boots;
                case "helmet":
                    return ItemType.Helmet;
                case "gloves":
                    return ItemType.Gloves;
                case "shield":
                    return ItemType.Shield;
                case "belt":
                    return ItemType.Belt;
                case "flasks":
                    return ItemType.Flasks;

                case "gems":
                    return ItemType.Gem;
                case "jewels":
                    return ItemType.Jewel;
                case "monsters":
                    return ItemType.BestiaryMonster;
                case "currency":
                    return ItemType.Currency;
                case "maps":
                    return ItemType.Map;
            }

            throw new NotImplementedException("FromString unimplemented for " + s);
        }

        public static bool IsWeapon(this ItemType eq)
        {
            return eq == ItemType.Wep1h || eq == ItemType.Wep2h;
        }

        public static bool IsEquipment(this ItemType id)
        {
            return id == ItemType.Body
            || id == ItemType.Boots
            || id == ItemType.Gloves
            || id == ItemType.Ring
            || id == ItemType.Amulet
            || id == ItemType.Helmet
            || id == ItemType.Wep1h
            || id == ItemType.Wep2h
            || id == ItemType.Shield;
        }

        public static String AsShortString(this ItemType type)
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
