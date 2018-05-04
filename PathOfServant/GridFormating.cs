using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        public static void MakeItemsSummary(Dictionary<ItemType, List<StashItemsFiltered>> itemsPerType, DataGridView grid)
        {
            grid.Rows.Clear();
            if (grid.Columns.Count == 0)
            {
                grid.Columns.Add("Type", "Type");
                grid.Columns.Add("Quantity", "Quantity");
                grid.Columns.Add("lowLvl", "lowlvl");
            }

            foreach (var typeEntry  in itemsPerType)
            {
                int lowLvl = 0;
                foreach (var item in typeEntry.Value)
                {
                    if (item.itlvl < 75) lowLvl++;
                }
                grid.Rows.Add(typeEntry.Key, typeEntry.Value.Count,lowLvl);
                Color bckColor = GetColorByItemType(typeEntry.Key);
                foreach (DataGridViewCell cell in grid.Rows[grid.Rows.Count-1].Cells)
                {
                    cell.Style.BackColor = bckColor;
                }
            }

            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

        }

        private static string GetIconLocalPath(string url)
        {
            
            string[] parts = url.Split('?')[0].Split('/');
            if (parts.Length > 6)
            {
                return "Icons\\"+parts[6] + "\\" + parts[7];
            }
            return null;
        }

        public static void SetGridColorsPerItem(Dictionary<ItemType, List<StashItemsFiltered>> itemsPerType, DataGridView grid, bool showItemIcon, List<PictureBox> pbs)
        {
            pbs.ForEach(pb => pb.Parent = null);
            pbs.Clear();
            foreach (var typeEntry in itemsPerType)
            {
                Color typeColor= GetColorByItemType(typeEntry.Key);
                foreach (var item in typeEntry.Value)
                {
                    if (showItemIcon)
                    {
                        string localIcon = GetIconLocalPath(item.icon);
                        Bitmap img = null;
                        if (System.IO.File.Exists(localIcon))
                        {
                            img = (Bitmap)Image.FromFile(localIcon);
                        }
                        else
                        {
                            img = WebTools.GetBitmapFromUrl(item.icon);
                            FileInfo file = new FileInfo(localIcon);
                            file.Directory.Create();
                            img.Save(localIcon, ImageFormat.Png);
                        }

                        var cellRectangle = grid.GetCellDisplayRectangle(item.x, item.y, false);
                        int imgHeigth = cellRectangle.Height * item.h;
                        int imgWidth = cellRectangle.Width * item.w;
                        PictureBox picBox = new PictureBox();
                        picBox.Parent = grid;
                        picBox.BringToFront();
                        picBox.Location = cellRectangle.Location;

                        Color transparencyColor = img.GetPixel(0, 0);
                        picBox.Size = new Size(imgWidth, imgHeigth);
                        picBox.SizeMode = PictureBoxSizeMode.Zoom;
                        picBox.BackColor = Color.Transparent;
                        picBox.Image = img;
                        pbs.Add(picBox);
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

        public static Color GetColorByItemType(ItemType itemType)
        {
            if (itemType.ToString()=="Wep1h")
            {

            }
            switch(itemType)
            {
                case ItemType.Amulet: return Color.Cyan;
                case ItemType.Body: return Color.Blue;
                case ItemType.Wep1h: return Color.LightGray;
                case ItemType.Wep2h: return Color.Yellow;
                case ItemType.Gloves: return Color.GreenYellow;
                case ItemType.Belt: return Color.Lime;
                case ItemType.Helmet: return Color.Violet;
                case ItemType.Ring: return Color.Brown;
                case ItemType.Boots: return Color.Orange;
                case ItemType.Currency: return Color.Gold;
                case ItemType.Jewel: return Color.DarkBlue;
                case ItemType.Gem: return Color.LightGreen;
                case ItemType.Fragment: return Color.SandyBrown;
                default: return Color.Red;
            }
        }
    }
}
