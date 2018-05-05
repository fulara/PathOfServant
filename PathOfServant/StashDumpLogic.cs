using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathOfServant
{
    class StashDumpLogic
    {
        Form1 form;

        Hotkey hotkey;
        Mouse mouse;
        Keyboard kb;
        Config config;

        Props props;

        public StashDumpLogic(Form1 form)
        {
            this.form = form;

            hotkey = new Hotkey(form);
            mouse = new Mouse();
            kb = new Keyboard();

            hotkey.Register(Hotkey.ModifierKeys.Control, Keys.D, () => { Dump(); });            
        }

        public void Dump()
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

            for (int i = 0; i < 15; ++i)
            {
                kb.Send(Keys.Left);
            }

            int currentIndex = 0;

            kb.SendDown(Keys.LControlKey);
            foreach (var items in dict.All)
            {
                if (items.Type == ItemType.Empty || items.Type == ItemType.Unknown)
                {
                    continue;
                }
                for (int x = 0; x < Props.X_COUNT - 1; ++x)
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

            while (currentIndex > targetIndex)
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
            //config.TabIndices.CurrenciesIndex = Convert.ToInt32(form.numericUpDownCurr.Value);
            //config.TabIndices.MapIndex = Convert.ToInt32(form.numericUpDownMaps.Value);
            //config.TabIndices.DivinationCardIndex = Convert.ToInt32(form.numericUpDownDvCards.Value);
            //config.TabIndices.FragmentIndex = Convert.ToInt32(form.numericUpDownFrags.Value);
            //config.TabIndices.EssencesIndex = Convert.ToInt32(form.numericUpDownEss.Value);

            //Nett.Toml.WriteFile(config, "config.toml");
        }
    }
}
