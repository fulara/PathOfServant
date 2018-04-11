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
        Hotkey hotkey;
        Mouse mouse;
        Keyboard kb;

        public Form1()
        {
            InitializeComponent();

            hotkey = new Hotkey(this);
            mouse = new Mouse();
            kb = new Keyboard();

            hotkey.Register(Hotkey.ModifierKeys.Control, Keys.D, () => { Scan(); });
        }

        private void itemScan_Click(object sender, EventArgs e)
        {
            Scan();
        }

        private void Scan()
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["imgPath"];

            var source = OpenCvHelpers.CaptureScreen();
            var dict = new ItemDictionary(path);
            var props = new Props(source, dict);
            var offset = new TabOffset();

            TabOffset.offsets[ItemType.Currency] = (int)numericUpDownCurr.Value-1;
            TabOffset.offsets[ItemType.Map] = (int)numericUpDownMaps.Value-1;
            TabOffset.offsets[ItemType.DivCard] = (int)numericUpDownDvCards.Value-1;
            TabOffset.offsets[ItemType.Fragments] = (int)numericUpDownFrag.Value-1;

            SaveTabOrder("currIndex", numericUpDownCurr.Value.ToString());
            SaveTabOrder("mapIndex", numericUpDownMaps.Value.ToString());
            SaveTabOrder("dvIndex", numericUpDownDvCards.Value.ToString());
            SaveTabOrder("fragIndex", numericUpDownFrag.Value.ToString());
            SaveTabOrder("essIndex", numericUpDownEss.Value.ToString());

            var pf = new PatternFinder(path, source, props, dict);

            var result = pf.DoSearch();

            DebugStuff.DumpResult(path, props, result, source);

            for(int i = 0; i < 15; ++i)
            {
                kb.Send(Keys.Left);
            }

            int currentIndex = 0;

            kb.SendDown(Keys.LControlKey);
            foreach (var items in dict.All)
            {
                if(items.Type == ItemType.Empty || items.Type == ItemType.Unknown)
                {
                    continue;
                }
                for (int x = 0; x < Props.X_COUNT; ++x)
                {
                    for (int y = 0; y < Props.Y_COUNT; ++y)
                    {
                        if (result[x, y] == items.Type)
                        {
                            //move it here so we do not do select if we did not have any items in stash
                            currentIndex = SelectTab(currentIndex, offset.GetOffset(items.Type));

                            var pos = props.TranslateToImage(x + 1, y + 1);
                            mouse.MouseLeftClick(pos.X, pos.Y);
                        }
                    }
                }
            }
            kb.SendUp(Keys.LControlKey);
        }

        private int SelectTab(int currentIndex, int targetIndex)
        {
            while(currentIndex > targetIndex)
            {
                kb.Send(Keys.Left);
                currentIndex--;
            }

            while (currentIndex < targetIndex)
            {
                kb.Send(Keys.Right);
                currentIndex++;
            }

            return currentIndex;
        }

        public static void SaveTabOrder(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                //ups
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            decimal currIndex = 1;
            decimal mapIndex = 1;
            decimal dvIndex = 1;
            decimal fragIndex = 1;
            decimal essIndex = 1;

            try
            {
                string currIndexTxt = System.Configuration.ConfigurationManager.AppSettings["currIndex"];
                string mapIndexTxt = System.Configuration.ConfigurationManager.AppSettings["mapIndex"];
                string dvIndexTxt = System.Configuration.ConfigurationManager.AppSettings["dvIndex"];
                string fragIndexTxt = System.Configuration.ConfigurationManager.AppSettings["fragIndex"];
                string essIndexTxt = System.Configuration.ConfigurationManager.AppSettings["essIndex"];

                decimal.TryParse(currIndexTxt, out currIndex);
                decimal.TryParse(mapIndexTxt, out mapIndex);
                decimal.TryParse(dvIndexTxt, out dvIndex);
                decimal.TryParse(fragIndexTxt, out fragIndex);
                decimal.TryParse(essIndexTxt, out essIndex);
            }
            catch(Exception ex)
            {

            }

            numericUpDownCurr.Value = currIndex;
            numericUpDownMaps.Value = mapIndex;
            numericUpDownDvCards.Value = dvIndex;
            numericUpDownFrag.Value= fragIndex;
            numericUpDownEss.Value = essIndex;
        }
    }
}
