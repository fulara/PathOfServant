using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathOfServant
{
    class StashSorterLogic
    {
        string charName = "";
        public List<RootObject> rootObjects = new List<RootObject>();
        private Stash charStash = new Stash();
        Dictionary<ItemType, List<StashItemsFiltered>> itemsPerType = new Dictionary<ItemType, List<StashItemsFiltered>>();
        Mouse mouse = new Mouse();
        Keyboard kb = new Keyboard();
        Int32 previousItemsCount = 0;
        List<PictureBox> itemIcons = new List<PictureBox>();

        Form1 form;
        Config config;

        public StashSorterLogic(Form1 form, Config config)
        {
            this.form = form;
            this.config = config;
        }

        public bool RefreshStash()
        {
            List<StashItemsFiltered> itemsFromWeb = WebTools.GetSetCollectionItemsFromWeb(config.Account, form.dataGridViewStashes);
            if (previousItemsCount != itemsFromWeb.Count)
            {
                previousItemsCount = itemsFromWeb.Count;
                form.dataGridViewStash.Rows.Clear();
                itemsPerType.Clear();
                itemsPerType = DataConversion.SortItemsToCategories(itemsFromWeb);
                GridFormating.SetGridRowsColumns(form.dataGridViewStash, true);
                GridFormating.SetGridColorsPerItem(itemsPerType, form.dataGridViewStash, form.checkBox1.Checked, itemIcons);
                GridFormating.MakeItemsSummary(itemsPerType, form.dataGridViewItems, form.dataGridViewSets);
                form.labelLastChange.Text = "Last change: "+System.DateTime.Now.ToLongTimeString();
                return true;
            }
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        public void ButtonPublicLoopClick()
        {
            charName = form.textBoxAcc.Text;

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                PublicStash.fillRootObjects(charStash, form.textBoxAcc.Text, PublicStash.GetLatestId());
            }).Start();
        }

        private void SetItemsPicked(List<StashItemsFiltered> pickedSet)
        {
            List<string> idList = pickedSet.Select(itm => itm.id).ToList();
            foreach (var typeEntry in itemsPerType)
            {
                foreach (var item in typeEntry.Value)
                {
                    if (idList.Contains(item.id))
                    {
                        item.picked = true;
                        Debug.WriteLine(item.typeName+" flagged picked");
                    }
                }
            }
        }

        public void PickSetButtonClick()
        {
            List<StashItemsFiltered> set = null;
            int setsNo = SetCalculation.HowManySets(itemsPerType);
            if (setsNo > 0)
            {
                Dictionary<ItemType, List<StashItemsFiltered>> itemsPerTypeCopy = new Dictionary<ItemType, List<StashItemsFiltered>>();
                foreach (var typeEntry in itemsPerType)
                {
                    List<StashItemsFiltered> newList = new List<StashItemsFiltered>();
                    foreach (StashItemsFiltered item in typeEntry.Value)
                    {
                        StashItemsFiltered newItem = StashItemsFiltered.Copy(item);
                        newList.Add(newItem);
                    }
                    itemsPerTypeCopy.Add(typeEntry.Key, newList);
                }

                set = SetCalculation.MakeSets(itemsPerTypeCopy);

                kb.SendDown(Keys.ControlKey);
                {
                    foreach (StashItemsFiltered item in set)
                    {
                        Tuple<int, int> click = Coordinates.GetClickCoordinates(item.x, item.y, item.quadLayout);
                        Thread.Sleep(50);
                        mouse.MouseLeftClick(click.Item1, click.Item2);
                    }
                }
                kb.SendUp(Keys.ControlKey);

                SetItemsPicked(set);
                Thread.Sleep(2000);
                RefreshStash();
            }
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
