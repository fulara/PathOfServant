using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathOfServant
{
    public class ItemDictionary
    {
        public class Items
        {
            public List<Item> ItemList { get; set; }
            public ItemType Type { get; set; }
        }

        public Items Currencies;
        public Items Maps;
        public Items DivCards;
        public Items Fragments;
        public Items Empty;

        public List<Items> All = new List<Items>();

        public Image<Bgr, byte> ForPositioning;

        public ItemDictionary(String path)
        {
            Empty = Load(path, "empty", ItemType.Empty);
            Currencies = Load(path, "currencies", ItemType.Currency);
            Maps = Load(path, "maps", ItemType.Map);
            DivCards = Load(path, "cards", ItemType.DivCard);
            Fragments = Load(path, "fragments", ItemType.Fragment);

            ForPositioning = new Image<Bgr, byte>(path + @"initial-lookup.png");
        }

        private Items Load(String basePath, String dirName, ItemType type)
        {
            String[] paths = Directory.GetFiles(Path.Combine(basePath, dirName), "*.png");

            var loadedItems = paths.Select(p =>
            {
                var name = Path.GetFileNameWithoutExtension(p);
                return new Item { Name = name, Type = type, Image = new Image<Bgr, byte>(p) };
            }).ToList();

            var items = new Items { ItemList = loadedItems, Type = type };

            All.Add(items);

            return items;
        }
    }
}
