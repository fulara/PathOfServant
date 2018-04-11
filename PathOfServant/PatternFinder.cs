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
using static PathOfServant.ItemDictionary;

namespace PathOfServant
{
    public class PatternFinder
    {
        //to  be removed.
        private String basePath;

        private ItemDictionary dictionary;
        private Image<Bgr, byte> source;
        private Props props;

        public PatternFinder(String basePath, Image<Bgr, byte> source, Props props, ItemDictionary dictionary)
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

        public void FindOccurences(ItemType[,] findResult, Items items)
        {
            foreach (var item in items.ItemList)
            {
                var template = item.Image;
                template.ROI = new Rectangle(template.Width * 2 / 3, 0, template.Width * 2 / 3, template.Height);

                for (var x = 0; x < Props.X_COUNT; ++x)
                {
                    for (var y = 0; y < Props.Y_COUNT; ++y)
                    {
                        if (findResult[x, y] == ItemType.Unknown)
                        {
                            if (IsPresentOnThisSquare(x, y, template))
                            {
                                findResult[x, y] = items.Type;
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

        public ItemType[,] DoSearch()
        {
            var findResult = CreateEmptyResultTable();

            foreach (var item in dictionary.All)
            {
                FindOccurences(findResult, item);
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
