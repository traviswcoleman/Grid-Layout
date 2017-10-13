using System;
using System.Drawing;
using System.Windows.Forms;
using Grid_Control;

namespace Grid_Layout
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            switch (nud.Name)
            {
                case "CellSize":
                    gridControl1.CellSize = (int)nud.Value;
                    break;

                case "XLimit":
                    if (nud.Value > 0)
                        gridControl1.XLimit = (int)nud.Value;
                    else
                        gridControl1.XLimit = null;
                    break;

                case "YLimit":
                    if (nud.Value > 0)
                        gridControl1.YLimit = (int)nud.Value;
                    else
                        gridControl1.YLimit = null;
                    break;

                case "MajorGU":
                    gridControl1.MajorGridUnit = (int)nud.Value;
                    break;

                case "MajorGT":
                    gridControl1.MajorGridThickness = (int)nud.Value;
                    break;

                case "MinorGU":
                    gridControl1.MinorGridUnit = (int)nud.Value;
                    break;

                case "MinorGT":
                    gridControl1.MinorGridThickness = (int)nud.Value;
                    break;
            }
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            switch (chk.Name)
            {
                case "chkMajorNum":
                    gridControl1.DisplayMajorNumbers = chk.Checked;
                    break;

                case "chkMinorNum":
                    gridControl1.DisplayMinorNumbers = chk.Checked;
                    break;

                case "chkDisplayNames":
                    gridControl1.DisplayNames = chk.Checked;
                    break;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void gridControl1_CellRegionSelected(object sender, GridControl.SelectionEventArgs e)
        {
            gridControl1.Cells.Add(new GridControl.CellInfo() { CellRegion = e.SelectedRegion, Color = Color.Red, DisplayName = false });
        }
    }
}