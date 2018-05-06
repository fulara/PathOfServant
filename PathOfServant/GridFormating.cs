using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PathOfServant.WebTools;

namespace PathOfServant
{
    class GridFormating
    {
        Form1 form;
        Config config;
        public GridFormating(Form1 form, Config config)
        {
            this.form = form;
            this.config = config;
        }
        enum Bla
        {
            Foo,
        }

        public static void FormatGriForUserTabs(List<TabInfo> userTabs, Config config, DataGridView grid)
        {
            Dictionary<string, string> tabCaptionToId = new Dictionary<string, string>();
            if (config.TabUsage != null)
            {
                if (config.TabUsage.Currency != null)
                {
                    if (!tabCaptionToId.ContainsKey(config.TabUsage.Currency))
                    {
                        tabCaptionToId.Add(config.TabUsage.Currency, "Currency");
                    }
                }
                if (config.TabUsage.DivCards != null)
                {
                    if (!tabCaptionToId.ContainsKey(config.TabUsage.DivCards))
                    {
                        tabCaptionToId.Add(config.TabUsage.DivCards, "DivCards");
                    }
                }
                if (config.TabUsage.Dump != null)
                {
                    if (!tabCaptionToId.ContainsKey(config.TabUsage.Dump))
                    {
                        tabCaptionToId.Add(config.TabUsage.Dump, "Dump");
                    }
                }
                if (config.TabUsage.Essences != null)
                {
                    if (!tabCaptionToId.ContainsKey(config.TabUsage.Essences))
                    {
                        tabCaptionToId.Add(config.TabUsage.Essences, "Essences");
                    }
                }
                if (config.TabUsage.Fragments != null)
                {
                    if (!tabCaptionToId.ContainsKey(config.TabUsage.Fragments))
                    {
                        tabCaptionToId.Add(config.TabUsage.Fragments, "Fragments");
                    }
                }
                if (config.TabUsage.Maps != null)
                {
                    if (!tabCaptionToId.ContainsKey(config.TabUsage.Maps))
                    {
                        tabCaptionToId.Add(config.TabUsage.Maps, "Maps");
                    }
                }
                if (config.TabUsage.Other != null)
                {
                    if (!tabCaptionToId.ContainsKey(config.TabUsage.Other))
                    {
                        tabCaptionToId.Add(config.TabUsage.Other, "Other");
                    }
                }
                if (config.TabUsage.SetCollection != null)
                {
                    if (!tabCaptionToId.ContainsKey(config.TabUsage.SetCollection))
                    {
                        tabCaptionToId.Add(config.TabUsage.SetCollection, "SetCollection");
                    }
                }
            }
            //var items = new List<string>{ "Currency ", "Maps", "Fragments", "DivCards", "Essences", "SetCollection", "Dump", "Other" };
            var items = config.TabUsage.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(i=>i.Name).ToArray();
            //var itemsv = config.TabUsage.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(i=>i.GetValue(config, null)).ToList();
            grid.Columns.Clear();
            DataGridViewTextBoxColumn captionCol = new DataGridViewTextBoxColumn();
            captionCol.HeaderText = "Caption";
            captionCol.Width = 80;
            DataGridViewTextBoxColumn typeCol = new DataGridViewTextBoxColumn();
            typeCol.HeaderText = "Type";
            typeCol.Width = 80;
            DataGridViewComboBoxColumn comboColum = new DataGridViewComboBoxColumn( );
            comboColum.HeaderText = "Usage";
            comboColum.Name = "Usage";
            comboColum.DataSource = items;
            comboColum.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            DataGridViewTextBoxColumn idCol = new DataGridViewTextBoxColumn();
            idCol.HeaderText = "id";
            idCol.Name = "id";
            idCol.Visible = false;


            grid.Columns.AddRange(captionCol, typeCol, comboColum, idCol);

                foreach (var tab in userTabs)
                {
                    grid.Rows.Add(tab.caption, tab.type,"",tab.id);
                    if (tabCaptionToId.ContainsKey(tab.id))
                    {
                         grid.Rows[grid.Rows.Count-1].Cells["Usage"].Value = tabCaptionToId[tab.id];
                    }
                }


        }



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

        public static void MakeItemsSummary(Dictionary<ItemType, List<StashItemsFiltered>> itemsPerType, DataGridView gridItems, DataGridView gridSets)
        {
            Dictionary<string, int> setsQty = new Dictionary<string, int>();
            setsQty.Add("Body", 0);
            setsQty.Add("Boots",0);
            setsQty.Add("Gloves",0);
            setsQty.Add("Ring", 0);
            setsQty.Add("Amulet", 0);
            setsQty.Add("Helmet", 0);
            setsQty.Add("Weapon", 0);
            setsQty.Add("Belt", 0);

            gridItems.Rows.Clear();
            if (gridItems.Columns.Count == 0)
            {
                gridItems.Columns.Add("Type", "Type");
                gridItems.Columns.Add("Quantity", "Items qty");
                gridItems.Columns.Add("lowLvl", "lowlvl");
            }

            foreach (var typeEntry  in itemsPerType)
            {
                int lowLvl = 0;
                foreach (var item in typeEntry.Value)
                {
                    if (item.itlvl < 75) lowLvl++;
                }
                gridItems.Rows.Add(typeEntry.Key, typeEntry.Value.Count,lowLvl);
                Color bckColor = GetColorByItemType(typeEntry.Key);
                foreach (DataGridViewCell cell in gridItems.Rows[gridItems.Rows.Count-1].Cells)
                {
                    cell.Style.BackColor = bckColor;
                }

                if (!typeEntry.Key.IsWeapon())
                {
                    if (!setsQty.ContainsKey(typeEntry.Key.ToString())) continue;
                    if (typeEntry.Key.ToString()!="Ring")
                    {
                        setsQty[typeEntry.Key.ToString()] = typeEntry.Value.Count;
                    }
                    else
                    {
                        setsQty[typeEntry.Key.ToString()] = typeEntry.Value.Count/2;
                    }
                }
                else
                {
                    if (typeEntry.Key.ToString() == "Wep1h")
                    {
                        setsQty["Weapon"] += typeEntry.Value.Count / 2;
                    }
                    else
                    {
                        setsQty["Weapon"] += typeEntry.Value.Count;
                    }
                }
                
            }

            gridSets.Rows.Clear();
            foreach (var tyeEntry in setsQty)
            {
                gridSets.Rows.Add(tyeEntry.Key, tyeEntry.Value);
            }
            gridSets.Sort(gridSets.Columns["SetsQty"], ListSortDirection.Ascending);

            foreach (DataGridViewColumn col in gridItems.Columns)
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
