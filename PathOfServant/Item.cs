using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathOfServant
{
    public class Item
    {
        public Image<Bgr, byte> Image { get; set; }
        public ItemType Type { get; set; }
        public String Name { get; set; }
    }
}
