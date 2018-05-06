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
            this.buttonShowTabs = new System.Windows.Forms.Button();
            this.league = new System.Windows.Forms.Label();
            this.comboBoxLeague = new System.Windows.Forms.ComboBox();
            this.labelLastChange = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxCookie = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxStashNo = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonPickSet = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.comboBoxStashName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAcc = new System.Windows.Forms.TextBox();
            this.dataGridViewSets = new System.Windows.Forms.DataGridView();
            this.Col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetsQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.dataGridViewStashes = new System.Windows.Forms.DataGridView();
            this.Caption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usage = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.hScrollBarX = new System.Windows.Forms.HScrollBar();
            this.hScrollBarY = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStash)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSets)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStashes)).BeginInit();
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
            this.dataGridViewStash.Size = new System.Drawing.Size(292, 368);
            this.dataGridViewStash.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // buttonPublicLoop
            // 
            this.buttonPublicLoop.Location = new System.Drawing.Point(542, 10);
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
            this.panel1.Controls.Add(this.hScrollBarY);
            this.panel1.Controls.Add(this.buttonPickSet);
            this.panel1.Controls.Add(this.hScrollBarX);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.buttonShowTabs);
            this.panel1.Controls.Add(this.league);
            this.panel1.Controls.Add(this.comboBoxLeague);
            this.panel1.Controls.Add(this.labelLastChange);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textBoxCookie);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxStashNo);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.buttonRefresh);
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
            // buttonShowTabs
            // 
            this.buttonShowTabs.Location = new System.Drawing.Point(611, 58);
            this.buttonShowTabs.Name = "buttonShowTabs";
            this.buttonShowTabs.Size = new System.Drawing.Size(279, 23);
            this.buttonShowTabs.TabIndex = 18;
            this.buttonShowTabs.Text = "Show Tabs";
            this.buttonShowTabs.UseVisualStyleBackColor = true;
            this.buttonShowTabs.Click += new System.EventHandler(this.buttonShowTabs_Click);
            // 
            // league
            // 
            this.league.AutoSize = true;
            this.league.Location = new System.Drawing.Point(608, 37);
            this.league.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.league.Name = "league";
            this.league.Size = new System.Drawing.Size(43, 13);
            this.league.TabIndex = 17;
            this.league.Text = "League";
            // 
            // comboBoxLeague
            // 
            this.comboBoxLeague.FormattingEnabled = true;
            this.comboBoxLeague.Items.AddRange(new object[] {
            "Bestiary",
            "Flashback Event (BRE001)"});
            this.comboBoxLeague.Location = new System.Drawing.Point(656, 34);
            this.comboBoxLeague.Name = "comboBoxLeague";
            this.comboBoxLeague.Size = new System.Drawing.Size(75, 21);
            this.comboBoxLeague.TabIndex = 16;
            this.comboBoxLeague.SelectedIndexChanged += new System.EventHandler(this.comboBoxLeague_SelectedIndexChanged);
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
            this.label10.Location = new System.Drawing.Point(414, 19);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Cookie:";
            // 
            // textBoxCookie
            // 
            this.textBoxCookie.Location = new System.Drawing.Point(462, 16);
            this.textBoxCookie.Name = "textBoxCookie";
            this.textBoxCookie.Size = new System.Drawing.Size(75, 20);
            this.textBoxCookie.TabIndex = 13;
            this.textBoxCookie.TextChanged += new System.EventHandler(this.textBoxCookie_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "StashNo";
            this.label4.Visible = false;
            // 
            // textBoxStashNo
            // 
            this.textBoxStashNo.Location = new System.Drawing.Point(265, 60);
            this.textBoxStashNo.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxStashNo.Name = "textBoxStashNo";
            this.textBoxStashNo.Size = new System.Drawing.Size(99, 20);
            this.textBoxStashNo.TabIndex = 11;
            this.textBoxStashNo.Text = "7";
            this.textBoxStashNo.Visible = false;
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
            this.buttonPickSet.Location = new System.Drawing.Point(345, 6);
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
            this.buttonRefresh.Location = new System.Drawing.Point(276, 6);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(65, 59);
            this.buttonRefresh.TabIndex = 8;
            this.buttonRefresh.Text = "refresh stash";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // comboBoxStashName
            // 
            this.comboBoxStashName.FormattingEnabled = true;
            this.comboBoxStashName.Location = new System.Drawing.Point(455, 41);
            this.comboBoxStashName.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxStashName.Name = "comboBoxStashName";
            this.comboBoxStashName.Size = new System.Drawing.Size(83, 21);
            this.comboBoxStashName.TabIndex = 5;
            this.comboBoxStashName.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Stash:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(759, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Acc";
            // 
            // textBoxAcc
            // 
            this.textBoxAcc.Location = new System.Drawing.Point(789, 33);
            this.textBoxAcc.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAcc.Name = "textBoxAcc";
            this.textBoxAcc.Size = new System.Drawing.Size(99, 20);
            this.textBoxAcc.TabIndex = 2;
            this.textBoxAcc.TextChanged += new System.EventHandler(this.textBoxAcc_TextChanged);
            // 
            // dataGridViewSets
            // 
            this.dataGridViewSets.AllowUserToAddRows = false;
            this.dataGridViewSets.AllowUserToDeleteRows = false;
            this.dataGridViewSets.AllowUserToResizeColumns = false;
            this.dataGridViewSets.AllowUserToResizeRows = false;
            this.dataGridViewSets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col1,
            this.SetsQty});
            this.dataGridViewSets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSets.Location = new System.Drawing.Point(478, 2);
            this.dataGridViewSets.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewSets.Name = "dataGridViewSets";
            this.dataGridViewSets.RowHeadersVisible = false;
            this.dataGridViewSets.RowTemplate.Height = 24;
            this.dataGridViewSets.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewSets.Size = new System.Drawing.Size(129, 368);
            this.dataGridViewSets.TabIndex = 9;
            // 
            // Col1
            // 
            this.Col1.HeaderText = "Type";
            this.Col1.Name = "Col1";
            this.Col1.ReadOnly = true;
            this.Col1.Width = 70;
            // 
            // SetsQty
            // 
            this.SetsQty.HeaderText = "Sets qty";
            this.SetsQty.Name = "SetsQty";
            this.SetsQty.ReadOnly = true;
            this.SetsQty.Width = 60;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.32888F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.26397F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.998F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.40915F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewItems, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewStash, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewSets, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewStashes, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 81);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(890, 372);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AllowUserToAddRows = false;
            this.dataGridViewItems.AllowUserToDeleteRows = false;
            this.dataGridViewItems.AllowUserToResizeColumns = false;
            this.dataGridViewItems.AllowUserToResizeRows = false;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewItems.Location = new System.Drawing.Point(298, 2);
            this.dataGridViewItems.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.RowHeadersVisible = false;
            this.dataGridViewItems.RowTemplate.Height = 24;
            this.dataGridViewItems.Size = new System.Drawing.Size(176, 368);
            this.dataGridViewItems.TabIndex = 12;
            // 
            // dataGridViewStashes
            // 
            this.dataGridViewStashes.AllowUserToAddRows = false;
            this.dataGridViewStashes.AllowUserToDeleteRows = false;
            this.dataGridViewStashes.AllowUserToResizeColumns = false;
            this.dataGridViewStashes.AllowUserToResizeRows = false;
            this.dataGridViewStashes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStashes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Caption,
            this.Type,
            this.Usage,
            this.id});
            this.dataGridViewStashes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStashes.Location = new System.Drawing.Point(611, 2);
            this.dataGridViewStashes.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewStashes.Name = "dataGridViewStashes";
            this.dataGridViewStashes.RowHeadersVisible = false;
            this.dataGridViewStashes.RowTemplate.Height = 24;
            this.dataGridViewStashes.Size = new System.Drawing.Size(277, 368);
            this.dataGridViewStashes.TabIndex = 11;
            this.dataGridViewStashes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStashes_CellValueChanged);
            // 
            // Caption
            // 
            this.Caption.HeaderText = "Caption";
            this.Caption.Name = "Caption";
            this.Caption.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Usage
            // 
            this.Usage.HeaderText = "Usage";
            this.Usage.Name = "Usage";
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 6);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(90, 17);
            this.checkBox2.TabIndex = 19;
            this.checkBox2.Text = "Show overlay";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // hScrollBarX
            // 
            this.hScrollBarX.Location = new System.Drawing.Point(102, 6);
            this.hScrollBarX.Name = "hScrollBarX";
            this.hScrollBarX.Size = new System.Drawing.Size(172, 24);
            this.hScrollBarX.TabIndex = 20;
            // 
            // hScrollBarY
            // 
            this.hScrollBarY.Location = new System.Drawing.Point(102, 31);
            this.hScrollBarY.Name = "hScrollBarY";
            this.hScrollBarY.Size = new System.Drawing.Size(172, 24);
            this.hScrollBarY.TabIndex = 21;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSets)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStashes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonPublicLoop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonPickSet;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ComboBox comboBoxStashName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataGridViewStash;
        public System.Windows.Forms.TextBox textBoxAcc;
        public System.Windows.Forms.TextBox textBoxStashNo;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.DataGridView dataGridViewSets;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox textBoxCookie;
        public System.Windows.Forms.Label labelLastChange;
        public System.Windows.Forms.DataGridView dataGridViewStashes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caption;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewComboBoxColumn Usage;
        private System.Windows.Forms.Label league;
        private System.Windows.Forms.ComboBox comboBoxLeague;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        public System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetsQty;
        private System.Windows.Forms.Button buttonShowTabs;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.HScrollBar hScrollBarY;
        private System.Windows.Forms.HScrollBar hScrollBarX;
    }
}

