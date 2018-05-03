using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathOfServant
{
    class GridFormating
    {
        public static void SetGridRowsColumns(DataGridView grid, bool quad)
        {
            grid.AllowUserToAddRows = false;
            grid.ColumnHeadersVisible = false;
            grid.RowHeadersVisible = false;
            grid.Columns.Clear();
            grid.Rows.Clear();
            
            int size = 0;
            if (quad)
            {
                size = 24;
            }
            else
            {
                size = 12;
            }

            for (int c = 0; c < size; c++) 
            {
                grid.Columns.Add(c.ToString(),c.ToString());
            }
            for (int r = 0; r < size; r++)
            {
                grid.Rows.Add();
            }
            int cellSize = Math.Min( grid.Size.Width ,grid.Size.Height) /size;

            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.Width = cellSize;
            }
            foreach (DataGridViewRow row in grid.Rows)
            {
                row.Height = cellSize;
            }
        }

        public static void MakeItemsSummary(Dictionary<string, List<StashItemsFiltered>> itemsPerType, DataGridView grid)
        {
            DataTable gridSource = new DataTable();
            gridSource.Columns.Add("Tyepe");
            gridSource.Columns.Add("Quantity");
            gridSource.Columns.Add("lowLvl");
            
            foreach (var typeEntry  in itemsPerType)
            {
                int lowLvl = 0;
                foreach (var item in typeEntry.Value)
                {
                    if (item.itlvl < 75) lowLvl++;
                }
                gridSource.Rows.Add(typeEntry.Key, typeEntry.Value.Count,lowLvl);

            }
            grid.DataSource = gridSource;
            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        public static void SetGridColorsPerItem(Dictionary<string, List<StashItemsFiltered>> itemsPerType, DataGridView grid, bool showItemIcon)
        {
            foreach (var typeEntry in itemsPerType)
            {
                Color typeColor= GetColorByItemType(typeEntry.Key);
                foreach (var item in typeEntry.Value)
                {
                    if (showItemIcon)
                    {
                        var cellRectangle = grid.GetCellDisplayRectangle(item.x, item.y, false);
                        int imgHeigth = cellRectangle.Height * item.h;
                        int imgWidth = cellRectangle.Width * item.w;
                        PictureBox picBox = new PictureBox();
                        picBox.Parent = grid;
                        picBox.BringToFront();
                        picBox.Location = cellRectangle.Location;
                        Bitmap img = WebTools.GetBitmapFromUrl(item.icon);
                        Color transparencyColor = img.GetPixel(0, 0);
                        picBox.Size = new Size(imgWidth, imgHeigth);
                        picBox.SizeMode = PictureBoxSizeMode.Zoom;
                        picBox.BackColor = Color.Transparent;
                        picBox.Image = img;
                    }
                    for (int x = item.x; x < item.x + item.w; x++) 
                    {
                        for (int y = item.y; y < item.y + item.h; y++)
                        {
                            grid.Rows[y].Cells[x].Style.BackColor = typeColor;
                            //grid.Rows[y].Cells[x].Tag = 
                           // grid.Rows[y].Cells[x].Tag= "x:" + item.x + " y:" + item.y + Environment.NewLine + "w:" + item.w + " h:" + item.h;
                            
                            
                        }
                    }
                }
            }
        }

        public static Color GetColorByItemType(string itemType)
        {
            switch(itemType)
            {
                case "amulet": return Color.Pink;
                case "chest": return Color.Blue;
                case "weapon": return Color.Yellow;
                case "gloves": return Color.GreenYellow;
                case "belt": return Color.Lime;
                case "helmet": return Color.Violet;
                case "ring": return Color.Brown;
                case "boots": return Color.Orange;
                default: return Color.White;
            }
        }
    }
}
