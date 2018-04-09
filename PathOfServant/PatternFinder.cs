using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathOfServant
{
    public class PatternFinder
    {
        //to  be removed.
        private String basePath;

        private ImageDictionary dictionary;
        private Image<Bgr, byte> source;
        private Props props;

        public PatternFinder(String basePath, Image<Bgr, byte> source, Props props, ImageDictionary dictionary)
        {
            this.props = props;
            this.source = source;
            this.basePath = basePath;
            this.dictionary = dictionary;
        }

        private bool IsPresentOnThisSquare(int x, int y, Image<Bgr, byte> template)
        {
            setRoi(x, y);

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcorrNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > 0.91)
                {
                    return true;
                }
            }

            return false;
        }

        public void FindOccurences(ItemType[,] findResult, IEnumerable<Image<Bgr, byte>> templates, ItemType type)
        {
            foreach (var template in templates)
            {
                template.ROI = new Rectangle(template.Width * 2 / 3, 0, template.Width * 2 / 3, template.Height);

                for (var x = 0; x < Props.X_COUNT; ++x)
                {
                    for (var y = 0; y < Props.Y_COUNT; ++y)
                    {
                        if (findResult[x, y] == ItemType.Unknown)
                        {
                            if (IsPresentOnThisSquare(x, y, template))
                            {
                                findResult[x, y] = type;
                            }
                        }
                    }
                }
            }

            source.ROI = Rectangle.Empty;
        }

        private static ItemType[,] CreateEmptyResultTable()
        {
            ItemType[,] result = new ItemType[Props.X_COUNT, Props.Y_COUNT];
            for (var x = 0; x < Props.X_COUNT; ++x)
            {
                for (var y = 0; y < Props.Y_COUNT; ++y)
                {
                    result[x, y] = ItemType.Unknown;
                }
            }

            return result;
        }

        public ItemType[,] DoSearch(Mapper mapper)
        {
            var findResult = CreateEmptyResultTable();

            //special case.
            FindOccurences(findResult, dictionary.Empty, ItemType.Empty);

            foreach (var mapEntry in mapper.Entries)
            {
                FindOccurences(findResult, mapEntry.images, mapEntry.type);
            }

            return findResult;
        }

        private void setRoi(int x, int y)
        {
            var pos = props.TranslateToImage(x, y);
            Rectangle r = new Rectangle(pos, new Size(Props.FRAME, Props.FRAME));
            source.ROI = r;
        }
    }
}
