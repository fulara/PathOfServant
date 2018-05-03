using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathOfServant
{
    class Coordinates
    {
        public static Tuple<int, int> GetClickCoordinates(int itemX, int itemY, bool quadStast)
        {
            double screenWidth = SystemInformation.VirtualScreen.Width;
            double screenHeigth = SystemInformation.VirtualScreen.Height;

            double cellSize = 0;

            double xStart = (double)16 / (double)1920 * screenWidth;
            double xEnd = (double)649 / (double)1920 * screenWidth;
            double xRange = (double)633 / (double)1920 * screenWidth;
            double yStart = (double)162 / (double)1080 * screenHeigth;
            double yEnd = (double)792 / (double)1080 * screenHeigth;



            if (quadStast)
            {
                cellSize = xRange / (double)24;
            }
            else
            {
                cellSize = xRange / (double)12;
            }

            double xClick = (xStart + (double)itemX * cellSize + cellSize / (double)2) ;
            double yClick = (yStart + (double)itemY * cellSize + cellSize / (double)2) ;

            return new Tuple<int, int>((int)Math.Round(xClick,0), (int)Math.Round(yClick,0));
        }

    }
}
