namespace PathOfServant
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewStash = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonPublicLoop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelLastChange = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxCookie = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxStashNo = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonPickSet = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.comboBoxStashName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAcc = new System.Windows.Forms.TextBox();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownEss = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownFrags = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownDvCards = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownMaps = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownCurr = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStash)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDvCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCurr)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStash
            // 
            this.dataGridViewStash.AllowUserToAddRows = false;
            this.dataGridViewStash.AllowUserToDeleteRows = false;
            this.dataGridViewStash.AllowUserToResizeColumns = false;
            this.dataGridViewStash.AllowUserToResizeRows = false;
            this.dataGridViewStash.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStash.Location = new System.Drawing.Point(2, 2);
            this.dataGridViewStash.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewStash.Name = "dataGridViewStash";
            this.dataGridViewStash.RowTemplate.Height = 24;
            this.dataGridViewStash.Size = new System.Drawing.Size(353, 368);
            this.dataGridViewStash.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // buttonPublicLoop
            // 
            this.buttonPublicLoop.Location = new System.Drawing.Point(576, 10);
            this.buttonPublicLoop.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPublicLoop.Name = "buttonPublicLoop";
            this.buttonPublicLoop.Size = new System.Drawing.Size(65, 59);
            this.buttonPublicLoop.TabIndex = 1;
            this.buttonPublicLoop.Text = "public loop";
            this.buttonPublicLoop.UseVisualStyleBackColor = true;
            this.buttonPublicLoop.Visible = false;
            this.buttonPublicLoop.Click += new System.EventHandler(this.buttonPublicLoop_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelLastChange);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textBoxCookie);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxStashNo);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.buttonPickSet);
            this.panel1.Controls.Add(this.buttonRefresh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxId);
            this.panel1.Controls.Add(this.comboBoxStashName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxAcc);
            this.panel1.Controls.Add(this.buttonPublicLoop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(890, 81);
            this.panel1.TabIndex = 5;
            // 
            // labelLastChange
            // 
            this.labelLastChange.AutoSize = true;
            this.labelLastChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLastChange.Location = new System.Drawing.Point(132, 63);
            this.labelLastChange.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLastChange.Name = "labelLastChange";
            this.labelLastChange.Size = new System.Drawing.Size(70, 13);
            this.labelLastChange.TabIndex = 15;
            this.labelLastChange.Text = "Last Change:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(364, 13);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Cookie:";
            // 
            // textBoxCookie
            // 
            this.textBoxCookie.Location = new System.Drawing.Point(408, 10);
            this.textBoxCookie.Name = "textBoxCookie";
            this.textBoxCookie.Size = new System.Drawing.Size(163, 20);
            this.textBoxCookie.TabIndex = 13;
            this.textBoxCookie.Text = "8dcfe28b4cd5d1ca884e2f2d539f8057";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "StashNo";
            // 
            // textBoxStashNo
            // 
            this.textBoxStashNo.Location = new System.Drawing.Point(61, 30);
            this.textBoxStashNo.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxStashNo.Name = "textBoxStashNo";
            this.textBoxStashNo.Size = new System.Drawing.Size(99, 20);
            this.textBoxStashNo.TabIndex = 11;
            this.textBoxStashNo.Text = "7";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 62);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(100, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Load item icons";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // buttonPickSet
            // 
            this.buttonPickSet.Location = new System.Drawing.Point(273, 3);
            this.buttonPickSet.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPickSet.Name = "buttonPickSet";
            this.buttonPickSet.Size = new System.Drawing.Size(65, 59);
            this.buttonPickSet.TabIndex = 9;
            this.buttonPickSet.Text = "Pick a set";
            this.buttonPickSet.UseVisualStyleBackColor = true;
            this.buttonPickSet.Click += new System.EventHandler(this.buttonPickSet_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(196, 3);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(65, 59);
            this.buttonRefresh.TabIndex = 8;
            this.buttonRefresh.Text = "refresh stash";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(715, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "start id";
            this.label3.Visible = false;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(758, 3);
            this.textBoxId.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(121, 20);
            this.textBoxId.TabIndex = 6;
            this.textBoxId.Text = "180609217-188060193-177101831-203691270-191104426";
            this.textBoxId.Visible = false;
            // 
            // comboBoxStashName
            // 
            this.comboBoxStashName.FormattingEnabled = true;
            this.comboBoxStashName.Location = new System.Drawing.Point(429, 35);
            this.comboBoxStashName.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxStashName.Name = "comboBoxStashName";
            this.comboBoxStashName.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStashName.TabIndex = 5;
            this.comboBoxStashName.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Stash:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Acc";
            // 
            // textBoxAcc
            // 
            this.textBoxAcc.Location = new System.Drawing.Point(61, 5);
            this.textBoxAcc.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAcc.Name = "textBoxAcc";
            this.textBoxAcc.Size = new System.Drawing.Size(99, 20);
            this.textBoxAcc.TabIndex = 2;
            this.textBoxAcc.Text = "piotrek816";
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AllowUserToAddRows = false;
            this.dataGridViewItems.AllowUserToDeleteRows = false;
            this.dataGridViewItems.AllowUserToResizeColumns = false;
            this.dataGridViewItems.AllowUserToResizeRows = false;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewItems.Location = new System.Drawing.Point(359, 2);
            this.dataGridViewItems.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.RowTemplate.Height = 24;
            this.dataGridViewItems.Size = new System.Drawing.Size(353, 368);
            this.dataGridViewItems.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewStash, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewItems, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 81);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(890, 372);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.numericUpDownEss);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.numericUpDownFrags);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.numericUpDownDvCards);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.numericUpDownMaps);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.numericUpDownCurr);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(717, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 366);
            this.panel2.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Essences";
            // 
            // numericUpDownEss
            // 
            this.numericUpDownEss.Location = new System.Drawing.Point(84, 122);
            this.numericUpDownEss.Name = "numericUpDownEss";
            this.numericUpDownEss.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownEss.TabIndex = 8;
            this.numericUpDownEss.Tag = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Frags";
            // 
            // numericUpDownFrags
            // 
            this.numericUpDownFrags.Location = new System.Drawing.Point(84, 99);
            this.numericUpDownFrags.Name = "numericUpDownFrags";
            this.numericUpDownFrags.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownFrags.TabIndex = 6;
            this.numericUpDownFrags.Tag = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Divs";
            // 
            // numericUpDownDvCards
            // 
            this.numericUpDownDvCards.Location = new System.Drawing.Point(84, 76);
            this.numericUpDownDvCards.Name = "numericUpDownDvCards";
            this.numericUpDownDvCards.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownDvCards.TabIndex = 4;
            this.numericUpDownDvCards.Tag = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Maps";
            // 
            // numericUpDownMaps
            // 
            this.numericUpDownMaps.Location = new System.Drawing.Point(84, 53);
            this.numericUpDownMaps.Name = "numericUpDownMaps";
            this.numericUpDownMaps.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownMaps.TabIndex = 2;
            this.numericUpDownMaps.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Curr";
            // 
            // numericUpDownCurr
            // 
            this.numericUpDownCurr.Location = new System.Drawing.Point(84, 29);
            this.numericUpDownCurr.Name = "numericUpDownCurr";
            this.numericUpDownCurr.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownCurr.TabIndex = 0;
            this.numericUpDownCurr.Tag = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 453);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStash)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDvCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCurr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonPublicLoop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonPickSet;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.ComboBox comboBoxStashName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataGridViewStash;
        public System.Windows.Forms.TextBox textBoxAcc;
        public System.Windows.Forms.TextBox textBoxStashNo;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown numericUpDownEss;
        public System.Windows.Forms.NumericUpDown numericUpDownFrags;
        public System.Windows.Forms.NumericUpDown numericUpDownDvCards;
        public System.Windows.Forms.NumericUpDown numericUpDownMaps;
        public System.Windows.Forms.NumericUpDown numericUpDownCurr;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox textBoxCookie;
        public System.Windows.Forms.Label labelLastChange;
    }
}

