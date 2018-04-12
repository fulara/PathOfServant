using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathOfServant
{
    public class Config
    {
        public String ImagesDirectory { get; set; }

        public TabIndices TabIndices { get; set; }
    }

    public class TabIndices
    {
        public int CurrenciesIndex { get; set; }
        public int MapIndex { get; set; }
        public int DivinationCardIndex { get; set; }
        public int FragmentIndex { get; set; }
        public int EssencesIndex { get; set; }
    }
}
