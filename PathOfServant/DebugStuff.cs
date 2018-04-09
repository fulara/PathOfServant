using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathOfServant
{
    public class DebugStuff
    {
        public static void DumpResult(String basePath, Props props, ItemType[,] findResult, Image<Bgr, byte> source)
        {
            for (var x = 0; x < Props.X_COUNT; ++x)
            {
                for (var y = 0; y < Props.Y_COUNT; ++y)
                {
                    var pos = props.TranslateToImage(x, y);
                    pos.X += Props.FRAME_EXTEND;
                    pos.Y += Props.FRAME_EXTEND;
                    Rectangle rect = new Rectangle(pos, new Size(10, 10));
                    switch (findResult[x, y])
                    {
                        case ItemType.Empty:
                            source.Draw(rect, new Bgr(Color.Red), 4);
                            break;
                        case ItemType.Unknown:
                            break;
                        case ItemType.Currency:
                            source.Draw(rect, new Bgr(Color.Yellow), 4);
                            break;
                        case ItemType.Map:
                            source.Draw(rect, new Bgr(Color.White), 4);
                            break;
                    }
                }
            }

            source.Save(basePath + @"result.png");
        }
    }
}
