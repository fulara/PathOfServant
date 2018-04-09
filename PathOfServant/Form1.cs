using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            string path = @"D:\Programming\Visual Projects\PathOfServant\imgs\";

            var source = OpenCvHelpers.CaptureScreen();
            var dict = new ImageDictionary(path);
            var props = new Props(source, dict);
            var mapper = new Mapper(dict);

            var pf = new PatternFinder(path, source, props, dict);

            var result = pf.DoSearch(mapper);

            DebugStuff.DumpResult(path, props, result, source);

            for(int i = 0; i < 15; ++i)
            {
                kb.Send(Keys.Left);
            }

            foreach (var mapEntry in mapper.Entries)
            {
                for (int i = 0; i < mapEntry.tabOffset; ++i)
                {
                    kb.Send(Keys.Right);
                }

                for (int x = 0; x < Props.X_COUNT; ++x)
                {
                    for (int y = 0; y < Props.Y_COUNT; ++y)
                    {
                        if (result[x, y] == mapEntry.type)
                        {
                            var pos = props.TranslateToImage(x + 1, y + 1);
                            kb.SendDown(Keys.LControlKey);
                            mouse.MouseLeftClick(pos.X, pos.Y);
                            kb.SendUp(Keys.LControlKey);
                        }
                    }
                }
            }
        }
    }
}
