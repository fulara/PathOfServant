using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PathOfServant.Hotkey;

namespace PathOfServant
{
    public partial class Form1 : Form
    {
        StashDumpLogic stashDumper;
        StashSorterLogic stashSorter;
        public Form1()
        {
            InitializeComponent();

            stashDumper = new StashDumpLogic(this);
            stashSorter = new StashSorterLogic(this);
            
        }

        private void itemScan_Click(object sender, EventArgs e)
        {
            stashDumper.Dump();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            stashSorter.RefreshStash();
        }

        private void buttonPickSet_Click(object sender, EventArgs e)
        {
            stashSorter.PickSetButtonClick();
        }

        private void buttonPublicLoop_Click(object sender, EventArgs e)
        {
            stashSorter.ButtonPublicLoopClick();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebTools.GetUserTabs();
        }
    }
}
