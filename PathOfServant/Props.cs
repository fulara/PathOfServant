using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathOfServant
{
    public class Props
    {
        public const double SHIFT = 52.5;

        public const int FRAME_EXTEND = 16;
        public const int FRAME = (int)(SHIFT + FRAME_EXTEND);

        public const int X_COUNT = 12;
        public const int Y_COUNT = 5;

        public Point PosZero;

        public Props(Image<Bgr, byte> source, ImageDictionary dictionary)
        {
            PosZero = FindPosZero(source, dictionary);
        }

        private static Point FindPosZero(Image<Bgr, byte> source, ImageDictionary dictionary)
        {
            using (Image<Gray, float> result = source.MatchTemplate(dictionary.ForPositioning, TemplateMatchingType.CcorrNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                return new Point((int)(maxLocations[0].X - FRAME_EXTEND / 2), (int)((maxLocations[0].Y + dictionary.ForPositioning.Height) - FRAME_EXTEND / 2));
            }
        }

        public Point TranslateToImage(int x, int y)
        {
            return new Point((int)(PosZero.X + SHIFT * x), (int)(PosZero.Y + SHIFT * y));
        }
    }
}
