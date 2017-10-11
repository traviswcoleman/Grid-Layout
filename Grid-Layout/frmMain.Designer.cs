namespace Grid_Layout
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.chkDisplayNames = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.XLimit = new System.Windows.Forms.NumericUpDown();
            this.YLimit = new System.Windows.Forms.NumericUpDown();
            this.CellSize = new System.Windows.Forms.NumericUpDown();
            this.MajorGU = new System.Windows.Forms.NumericUpDown();
            this.MajorGT = new System.Windows.Forms.NumericUpDown();
            this.MinorGU = new System.Windows.Forms.NumericUpDown();
            this.MinorGT = new System.Windows.Forms.NumericUpDown();
            this.chkMajorNum = new System.Windows.Forms.CheckBox();
            this.chkMinorNum = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gridControl1 = new Grid_Layout.Controls.GridControl();
            this.gridControlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.XLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MajorGU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MajorGT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinorGU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinorGT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chkDisplayNames
            // 
            this.chkDisplayNames.AutoSize = true;
            this.chkDisplayNames.Checked = true;
            this.chkDisplayNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisplayNames.Location = new System.Drawing.Point(171, 260);
            this.chkDisplayNames.Name = "chkDisplayNames";
            this.chkDisplayNames.Size = new System.Drawing.Size(18, 17);
            this.chkDisplayNames.TabIndex = 21;
            this.chkDisplayNames.UseVisualStyleBackColor = true;
            this.chkDisplayNames.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(66, 257);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 23);
            this.label10.TabIndex = 20;
            this.label10.Text = "Display Names";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 297);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Display Minor Numbers";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 277);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 23);
            this.label8.TabIndex = 16;
            this.label8.Text = "Display Major Numbers";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "X Limit";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y Limit";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cell Size";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Major Grid Unit";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "Major Grid Thickness";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Minor Grid Unit";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 23);
            this.label7.TabIndex = 7;
            this.label7.Text = "Minor Grid Thickness";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // XLimit
            // 
            this.XLimit.Location = new System.Drawing.Point(171, 12);
            this.XLimit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.XLimit.Name = "XLimit";
            this.XLimit.Size = new System.Drawing.Size(120, 30);
            this.XLimit.TabIndex = 8;
            this.XLimit.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.XLimit.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // YLimit
            // 
            this.YLimit.Location = new System.Drawing.Point(171, 48);
            this.YLimit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.YLimit.Name = "YLimit";
            this.YLimit.Size = new System.Drawing.Size(120, 30);
            this.YLimit.TabIndex = 9;
            this.YLimit.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.YLimit.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // CellSize
            // 
            this.CellSize.Location = new System.Drawing.Point(171, 84);
            this.CellSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CellSize.Name = "CellSize";
            this.CellSize.Size = new System.Drawing.Size(120, 30);
            this.CellSize.TabIndex = 10;
            this.CellSize.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.CellSize.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // MajorGU
            // 
            this.MajorGU.Location = new System.Drawing.Point(171, 120);
            this.MajorGU.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MajorGU.Name = "MajorGU";
            this.MajorGU.Size = new System.Drawing.Size(120, 30);
            this.MajorGU.TabIndex = 11;
            this.MajorGU.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.MajorGU.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // MajorGT
            // 
            this.MajorGT.Location = new System.Drawing.Point(171, 156);
            this.MajorGT.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MajorGT.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MajorGT.Name = "MajorGT";
            this.MajorGT.Size = new System.Drawing.Size(120, 30);
            this.MajorGT.TabIndex = 12;
            this.MajorGT.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.MajorGT.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // MinorGU
            // 
            this.MinorGU.Location = new System.Drawing.Point(171, 192);
            this.MinorGU.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinorGU.Name = "MinorGU";
            this.MinorGU.Size = new System.Drawing.Size(120, 30);
            this.MinorGU.TabIndex = 13;
            this.MinorGU.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinorGU.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // MinorGT
            // 
            this.MinorGT.Location = new System.Drawing.Point(171, 228);
            this.MinorGT.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinorGT.Name = "MinorGT";
            this.MinorGT.Size = new System.Drawing.Size(120, 30);
            this.MinorGT.TabIndex = 14;
            this.MinorGT.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinorGT.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // chkMajorNum
            // 
            this.chkMajorNum.AutoSize = true;
            this.chkMajorNum.Checked = true;
            this.chkMajorNum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMajorNum.Location = new System.Drawing.Point(171, 280);
            this.chkMajorNum.Name = "chkMajorNum";
            this.chkMajorNum.Size = new System.Drawing.Size(18, 17);
            this.chkMajorNum.TabIndex = 18;
            this.chkMajorNum.UseVisualStyleBackColor = true;
            this.chkMajorNum.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkMinorNum
            // 
            this.chkMinorNum.AutoSize = true;
            this.chkMinorNum.Location = new System.Drawing.Point(171, 300);
            this.chkMinorNum.Name = "chkMinorNum";
            this.chkMinorNum.Size = new System.Drawing.Size(18, 17);
            this.chkMinorNum.TabIndex = 19;
            this.chkMinorNum.UseVisualStyleBackColor = true;
            this.chkMinorNum.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(112, 315);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 23);
            this.label11.TabIndex = 23;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gridControl1.BackColor = System.Drawing.Color.Silver;
            this.gridControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(298, 12);
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(464, 547);
            this.gridControl1.TabIndex = 22;
            this.gridControl1.XLimit = 20;
            this.gridControl1.YLimit = 25;
            this.gridControl1.CellRegionSelected += new Grid_Layout.Controls.GridControl.RegionSelectedEventHandler(this.gridControl1_CellRegionSelected);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 572);
            this.Controls.Add(this.chkDisplayNames);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.XLimit);
            this.Controls.Add(this.YLimit);
            this.Controls.Add(this.CellSize);
            this.Controls.Add(this.MajorGU);
            this.Controls.Add(this.MajorGT);
            this.Controls.Add(this.MinorGU);
            this.Controls.Add(this.MinorGT);
            this.Controls.Add(this.chkMajorNum);
            this.Controls.Add(this.chkMinorNum);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label11);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Grid Layout";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.XLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MajorGU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MajorGT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinorGU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinorGT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown XLimit;
        private System.Windows.Forms.NumericUpDown YLimit;
        private System.Windows.Forms.NumericUpDown CellSize;
        private System.Windows.Forms.NumericUpDown MajorGU;
        private System.Windows.Forms.NumericUpDown MajorGT;
        private System.Windows.Forms.NumericUpDown MinorGU;
        private System.Windows.Forms.NumericUpDown MinorGT;
        private System.Windows.Forms.BindingSource gridControlBindingSource;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkMajorNum;
        private System.Windows.Forms.CheckBox chkMinorNum;
        private System.Windows.Forms.CheckBox chkDisplayNames;
        private System.Windows.Forms.Label label10;
        private Controls.GridControl gridControl1;
        private System.Windows.Forms.Label label11;
    }
}

