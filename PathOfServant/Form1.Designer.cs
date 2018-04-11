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
            this.itemScan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownMaps = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCurr = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDvCards = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFrag = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownEss = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCurr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDvCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEss)).BeginInit();
            this.SuspendLayout();
            // 
            // itemScan
            // 
            this.itemScan.Location = new System.Drawing.Point(108, 207);
            this.itemScan.Name = "itemScan";
            this.itemScan.Size = new System.Drawing.Size(75, 23);
            this.itemScan.TabIndex = 0;
            this.itemScan.Text = "ItemScan";
            this.itemScan.UseVisualStyleBackColor = true;
            this.itemScan.Click += new System.EventHandler(this.itemScan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Maps";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Currency";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Dv Cards";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fragments";
            // 
            // numericUpDownMaps
            // 
            this.numericUpDownMaps.Location = new System.Drawing.Point(67, 7);
            this.numericUpDownMaps.Name = "numericUpDownMaps";
            this.numericUpDownMaps.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownMaps.TabIndex = 5;
            this.numericUpDownMaps.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDownCurr
            // 
            this.numericUpDownCurr.Location = new System.Drawing.Point(67, 26);
            this.numericUpDownCurr.Name = "numericUpDownCurr";
            this.numericUpDownCurr.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownCurr.TabIndex = 6;
            this.numericUpDownCurr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownDvCards
            // 
            this.numericUpDownDvCards.Location = new System.Drawing.Point(67, 45);
            this.numericUpDownDvCards.Name = "numericUpDownDvCards";
            this.numericUpDownDvCards.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownDvCards.TabIndex = 7;
            this.numericUpDownDvCards.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numericUpDownFrag
            // 
            this.numericUpDownFrag.Location = new System.Drawing.Point(67, 64);
            this.numericUpDownFrag.Name = "numericUpDownFrag";
            this.numericUpDownFrag.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownFrag.TabIndex = 8;
            this.numericUpDownFrag.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Essence";
            // 
            // numericUpDownEss
            // 
            this.numericUpDownEss.Location = new System.Drawing.Point(67, 82);
            this.numericUpDownEss.Name = "numericUpDownEss";
            this.numericUpDownEss.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownEss.TabIndex = 10;
            this.numericUpDownEss.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.numericUpDownEss);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownFrag);
            this.Controls.Add(this.numericUpDownDvCards);
            this.Controls.Add(this.numericUpDownCurr);
            this.Controls.Add(this.numericUpDownMaps);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemScan);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCurr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDvCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEss)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button itemScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownMaps;
        private System.Windows.Forms.NumericUpDown numericUpDownCurr;
        private System.Windows.Forms.NumericUpDown numericUpDownDvCards;
        private System.Windows.Forms.NumericUpDown numericUpDownFrag;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownEss;
    }
}

