using System;
using System.Collections.Generic;
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
        Dictionary<string, List<StashItemsFiltered>> itemsPerType = new Dictionary<string, List<StashItemsFiltered>>();
        Dictionary<string, string> itemData = new Dictionary<string, string>();
        Mouse mouse = new Mouse();
        Keyboard kb = new Keyboard();

        Form1 form;

        public StashSorterLogic(Form1 form)
        {
            this.form = form;
        }

        public void RefreshStash()
        {
            //try
            {
                itemsPerType.Clear();
                itemsPerType = DataConversion.SortItemsToCategories(itemData, WebTools.GetStashItemsFromWeb(form.textBoxAcc.Text, form.textBoxStashNo.Text));
                GridFormating.SetGridRowsColumns(form.dataGridViewStash, true);
                GridFormating.SetGridColorsPerItem(itemsPerType, form.dataGridViewStash, form.checkBox1.Checked);
                GridFormating.MakeItemsSummary(itemsPerType, form.dataGridViewItems);
            }
            //catch (Exception ex) { MessageBox.Show("Something went wrong :("+Environment.NewLine+ex.Message+Environment.NewLine+ex.StackTrace); }
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

        public void PickSetButtonClick()
        {
            List<StashItemsFiltered> set = null;
            int setsNo = SetCalculation.HowManySets(itemsPerType);
            if (setsNo > 0)
            {
                Dictionary<string, List<StashItemsFiltered>> itemsPerTypeCopy = new Dictionary<string, List<StashItemsFiltered>>();
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

                Thread.Sleep(2000);
                RefreshStash();
            }
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
