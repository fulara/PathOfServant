using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathOfServant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string path = @"D:\Programming\Visual Projects\PathOfServant\imgs\";

            var source = new Image<Emgu.CV.Structure.Bgr, byte>(Path.Combine(path, "full.png"));
            var dict = new ImageDictionary(path);
            var props = new Props(source, dict);
            var pf = new PatternFinder(path, source, props, dict);

            var result = pf.DoSearch();

            DebugStuff.DumpResult(path, props, result, source);
        }
    }
}
