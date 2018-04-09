using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathOfServant
{
    public class Mapper
    {
        public class Entry
        {
            public List<Image<Bgr, byte>> images;
            public ItemType type;
            public int tabOffset;
        }

        public Mapper(ImageDictionary dictionary)
        {
            Entries = new List<Entry>();

            Entries.Add(new Entry { images = dictionary.Maps, type = ItemType.Map, tabOffset = 1 });
            Entries.Add(new Entry { images = dictionary.Currencies, type = ItemType.Currency, tabOffset = 1 });
            Entries.Add(new Entry { images = dictionary.DivCards, type = ItemType.DivCard, tabOffset = 3 });
        }

        public List<Entry> Entries { get; private set; }

    }
}
