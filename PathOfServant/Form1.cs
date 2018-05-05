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

        Config config = Nett.Toml.ReadFile<Config>("config.toml");
        public Form1()
        {
            InitializeComponent();            

            stashDumper = new StashDumpLogic(this);
            stashSorter = new StashSorterLogic(this, config);
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
            //GridFormating.FormatGriForUserTabs(WebTools.GetUserTabs(config.Account), dataGridViewStashes);
            
        }

        private void textBoxAcc_TextChanged(object sender, EventArgs e)
        {
            config.Account.Name = textBoxAcc.Text;
            config.Save();
        }

        private void textBoxCookie_TextChanged(object sender, EventArgs e)
        {
            config.Account.Cookie = textBoxCookie.Text;
            config.Save();
        }

        private void comboBoxLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.Account.League = comboBoxLeague.Text;
            config.Save();
        }

        private void LoadConfig()
        {
            if (config.Account == null)
            {
                config.Account = new Account();
            }

            if (String.IsNullOrEmpty(config.Account.Cookie))
            {
                IEnumerable<Tuple<string, string>> results = WebTools.ReadCookies(".pathofexile.com");
                Tuple<string, string> result = results.Where(x => x.Item1 == "POESESSID").First();
                config.Account.Cookie = result.Item2;

                config.Save();
            }

            textBoxAcc.Text = config.Account.Name;
            textBoxCookie.Text = config.Account.Cookie;
            comboBoxLeague.Text = config.Account.League;

        }
    }
}
