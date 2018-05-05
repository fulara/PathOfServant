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
        public TabUsage TabUsage { get; set; }
        public TabIndices TabIndices { get; set; }
        public Account Account { get; set; }

        public void Save()
        {
            Nett.Toml.WriteFile(this, "config.toml");
        }
    }

    public class TabIndices
    {
        public int CurrenciesIndex { get; set; }
        public int MapIndex { get; set; }
        public int DivinationCardIndex { get; set; }
        public int FragmentIndex { get; set; }
        public int EssencesIndex { get; set; }
    }

    public class TabUsage
    {
        public string Currency  { get; set; }
        public string Maps { get; set; }
        public string Fragments { get; set; }
        public string DivCards { get; set; }
        public string Essences { get; set; }
        public string SetCollection { get; set; }
        public string Dump { get; set; }
        public string Other { get; set; }
    }

    public class Account
    {
        public string Name { get; set; }
        public string Cookie { get; set; }
        public string League { get; set; }
    }
}
