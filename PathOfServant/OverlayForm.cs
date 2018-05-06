using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PathOfServant
{
    public partial class OverlayForm : Form
    {
        private readonly HScrollBar scrollX;
        private readonly HScrollBar scrollY;
        private readonly DataGridView gridSets;

        public OverlayForm(CheckBox formCheckbox, DataGridView gridSets, HScrollBar scrollX, HScrollBar scrollY)
        {
            InitializeComponent();
            this.TopMost = true; // make the form always on top
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // hidden border
            this.WindowState = FormWindowState.Maximized; // maximized
            this.MinimizeBox = this.MaximizeBox = false; // not allowed to be minimized
            this.MinimumSize = this.MaximumSize = this.Size; // not allowed to be resized
            this.TransparencyKey = this.BackColor = Color.Red; // the color key to transparent, choose a color that you don't use

            //int initialStyle = GetWindowLong(this.Handle, -20);
            //SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);

            formCheckbox.CheckedChanged += new EventHandler(formCheck_checkChanged);
            scrollX.ValueChanged += new EventHandler(scroll_ValueChanged);
            scrollY.ValueChanged += new EventHandler(scroll_ValueChanged);
            //gridSets.CellValueChanged += new DataGridViewCellEventHandler(gridSets_CellValueChanged);

            this.scrollX = scrollX;
            this.scrollY = scrollY;
            this.gridSets = gridSets;
        }

        private void scroll_ValueChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private string[] GridTostring()
        {
            List<string> result = new List<string>();
            result.Add("Sets:");
            foreach (DataGridViewRow row in gridSets.Rows)
            {
                result.Add(row.Cells[0].Value.ToString() + " " + row.Cells[1].Value.ToString());
            }
            return result.ToArray(); ;
        }

        private void gridSets_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.Refresh();
        }

        private void formCheck_checkChanged(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // Set the form click-through
                cp.ExStyle |= 0x80000 /* WS_EX_LAYERED */ | 0x20 /* WS_EX_TRANSPARENT */;
                return cp;
            }
        }

        public DataGridView GridSets { get; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // draw what you want
            //e.Graphics.FillEllipse(Brushes.Blue, 30, 30, 100, 100);
            string[] overlayText = GridTostring();
            float linespacing = 20;
            for(int i=0;i<overlayText.Length;i++)
            {
                //Graphics g = this.CreateGraphics();
                //GraphicsPath fontpath = new GraphicsPath();
                //fontpath.AddString(overlayText[i], new FontFamily("Tahoma"),(int)FontStyle.Regular, 18, new PointF(scrollX.Value, scrollY.Value + linespacing * i), StringFormat.GenericDefault);
                //PathGradientBrush pgb = new System.Drawing.Drawing2D.PathGradientBrush(fontpath);
                //Color[] c = { (Color.Transparent) };
                //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //pgb.CenterColor = Color.FromArgb(255, Color.Red);

                //pgb.SurroundColors = c;

                //g.FillPath(Brushes.Blue, fontpath);


                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                e.Graphics.DrawString(overlayText[i], this.Font, Brushes.Blue, new PointF(scrollX.Value, scrollY.Value+linespacing*i));
            }

        }

        private void OverlayForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
