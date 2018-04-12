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
        Config config;

        Props props;

        public Form1()
        {
            InitializeComponent();

            hotkey = new Hotkey(this);
            mouse = new Mouse();
            kb = new Keyboard();

            hotkey.Register(Hotkey.ModifierKeys.Control, Keys.D, () => { Scan(); });

            config = Nett.Toml.ReadFile<Config>("config.toml");
        }

        private void itemScan_Click(object sender, EventArgs e)
        {
            Scan();
        }

        private void Scan()
        {
            var source = OpenCvHelpers.CaptureScreen();
            var path = config.ImagesDirectory + "/";
            var dict = new ItemDictionary(path);

            if (props == null)
            {
                props = new Props(source, dict);
            }
            var offset = new TabOffset();
            offset.UpdateOffsets(config.TabIndices);

            var pf = new PatternFinder(path, source, props, dict);

            var result = pf.DoSearch();

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
                for (int x = 1; x < Props.X_COUNT; ++x)
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
            if (currentIndex == targetIndex)
            {
                return currentIndex;
            }

            Thread.Sleep(100);

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

        public void SaveTabOrder()
        {
            config.TabIndices.CurrenciesIndex = Convert.ToInt32(numericUpDownCurr.Value);
            config.TabIndices.MapIndex = Convert.ToInt32(numericUpDownMaps.Value);
            config.TabIndices.DivinationCardIndex = Convert.ToInt32(numericUpDownDvCards.Value);
            config.TabIndices.FragmentIndex = Convert.ToInt32(numericUpDownFrag.Value);
            config.TabIndices.EssencesIndex = Convert.ToInt32(numericUpDownEss.Value);

            Nett.Toml.WriteFile(config, "config.toml");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            config = Nett.Toml.ReadFile<Config>("config.toml");
        }
    }
}
