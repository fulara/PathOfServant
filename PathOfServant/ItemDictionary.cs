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
    public class ImageDictionary
    {
        public List<Image<Bgr, byte>> Currencies;
        public List<Image<Bgr, byte>> Maps;
        public List<Image<Bgr, byte>> DivCards;
        public List<Image<Bgr, byte>> Empty;

        public Image<Bgr, byte> ForPositioning;

        public ImageDictionary(String path)
        {
            Currencies = Load(path, "currencies");
            Maps = Load(path, "maps");
            DivCards = Load(path, "cards");
            Empty = Load(path, "empty");

            ForPositioning = new Image<Bgr, byte>(path + @"initial-lookup.png");
        }

        private List<Image<Bgr, byte>> Load(String basePath, String dirName)
        {
            String[] paths = Directory.GetFiles(Path.Combine(basePath, dirName), "*.png");

            return paths.Select(p =>
            {
                return new Image<Bgr, byte>(p);
            }).ToList();
        }
    }
}
