namespace Grid_Layout.Controls
{
    partial class GridControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hScroll = new System.Windows.Forms.HScrollBar();
            this.vScroll = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // hScroll
            // 
            this.hScroll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScroll.Location = new System.Drawing.Point(0, 445);
            this.hScroll.Name = "hScroll";
            this.hScroll.Size = new System.Drawing.Size(473, 21);
            this.hScroll.SmallChange = 0;
            this.hScroll.TabIndex = 0;
            this.hScroll.Visible = false;
            // 
            // vScroll
            // 
            this.vScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScroll.Location = new System.Drawing.Point(452, 0);
            this.vScroll.Maximum = 1000;
            this.vScroll.Name = "vScroll";
            this.vScroll.Size = new System.Drawing.Size(21, 445);
            this.vScroll.TabIndex = 1;
            this.vScroll.Visible = false;
            // 
            // GridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.vScroll);
            this.Controls.Add(this.hScroll);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GridControl";
            this.Size = new System.Drawing.Size(473, 466);
            this.Load += new System.EventHandler(this.GridControl_Load);
            this.ClientSizeChanged += new System.EventHandler(this.GridControl_Resize);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GridControl_Paint);
            this.Resize += new System.EventHandler(this.GridControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HScrollBar hScroll;
        private System.Windows.Forms.VScrollBar vScroll;
    }
}
