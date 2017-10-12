using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Grid_Layout.Controls
{
    public partial class GridControl : UserControl
    {
        #region Classes

        [Serializable]
        public class CellInfo
        {
            public CellInfo()
            {
            }

            public CellInfo(Rectangle cellRegion, Color color, bool displayName = false, string name = "")
            {
                this.CellRegion = cellRegion;
                this.Color = color;
                this.DisplayName = displayName;
                this.Name = name;
            }

            public Rectangle CellRegion { get; set; }

            public Color Color { get; set; }

            public bool DisplayName { get; set; }

            public string Name { get; set; }
        }

        public class SelectionEventArgs : EventArgs
        {
            public SelectionEventArgs(Rectangle SelectedRegion)
            {
                this.SelectedRegion = SelectedRegion;
            }

            public Rectangle SelectedRegion { get; set; }
        }

        #endregion Classes

        public GridControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            backBrush = new SolidBrush(this.BackColor);
            foreBrush = new SolidBrush(this.ForeColor);

            highlightBrush = new SolidBrush(Color.FromArgb(80, Color.Blue));
            highlightPen = new Pen(Color.FromArgb(160, Color.Blue), 5);

            vScroll.LargeChange = hScroll.LargeChange = MajorGridUnit;
            vScroll.SmallChange = hScroll.SmallChange = MinorGridUnit;

            this.BackColorChanged += GridControl_BackColorChanged;
            this.ForeColorChanged += GridControl_ForeColorChanged;
            this.MouseDown += GridControl_MouseDown;
            this.MouseUp += GridControl_MouseUp;
            this.MouseMove += GridControl_MouseMove;
        }

        private Brush backBrush;
        private Point curLoc = new Point(0, 0);
        private Brush foreBrush;
        private Brush highlightBrush;
        private Pen highlightPen;
        private Point? mouseDown = null;
        private Pen thickPen = new Pen(Brushes.Black, 5);
        private Pen thinPen = new Pen(Brushes.Black, 1);

        #region Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<CellInfo> Cells
        {
            get
            {
                if (_cells == null)
                    _cells = new List<CellInfo>();
                return _cells;
            }
        }

        [DefaultValue(20)]
        [Category("Grid")]
        public int CellSize
        {
            get { return _cellSize; }
            set
            {
                _cellSize = value;
                setScrollBars();
                this.Invalidate();
            }
        }

        [Category("Grid")]
        [DefaultValue(true)]
        public bool DisplayMajorNumbers
        {
            get { return _displayMajorNumbers; }
            set
            {
                _displayMajorNumbers = value;
                this.Invalidate();
            }
        }

        [Category("Grid")]
        [DefaultValue(false)]
        public bool DisplayMinorNumbers
        {
            get { return _displayMinorNumbers; }
            set
            {
                _displayMinorNumbers = value;
                this.Invalidate();
            }
        }

        [Category("Grid")]
        [DefaultValue(true)]
        public bool DisplayNames
        {
            get { return _displayNames; }
            set
            {
                _displayNames = value;
                this.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "0x000000")]
        [Category("Grid")]
        public Color MajorGridColor
        {
            get
            {
                return _majorGridColor;
            }
            set
            {
                _majorGridColor = value;
                thickPen = new Pen(new SolidBrush(MajorGridColor), MajorGridThickness);
                this.Invalidate();
            }
        }

        [DefaultValue(5)]
        [Category("Grid")]
        public int MajorGridThickness
        {
            get
            {
                return _majorGridThickness;
            }
            set
            {
                _majorGridThickness = value;
                thickPen = new Pen(new SolidBrush(MajorGridColor), _majorGridThickness);
                this.Invalidate();
            }
        }

        [DefaultValue(5)]
        [Category("Grid")]
        public int MajorGridUnit
        {
            get { return _majorGridUnit; }
            set
            {
                _majorGridUnit = value;
                hScroll.LargeChange = _majorGridUnit;
                vScroll.LargeChange = _majorGridUnit;
                this.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "0x000000")]
        [Category("Grid")]
        public Color MinorGridColor
        {
            get
            {
                return _minorGridColor;
            }
            set
            {
                _minorGridColor = value;
                thinPen = new Pen(new SolidBrush(MinorGridColor), _minorGridThickness);
                this.Invalidate();
            }
        }

        [DefaultValue(1)]
        [Category("Grid")]
        public int MinorGridThickness
        {
            get
            {
                return _minorGridThickness;
            }
            set
            {
                _minorGridThickness = value;
                thinPen = new Pen(new SolidBrush(MinorGridColor), _minorGridThickness);
                this.Invalidate();
            }
        }

        [DefaultValue(1)]
        [Category("Grid")]
        public int MinorGridUnit
        {
            get { return _minorGridUnit; }
            set
            {
                _minorGridUnit = value;
                hScroll.SmallChange = _minorGridUnit;
                vScroll.SmallChange = _minorGridUnit;
                this.Invalidate();
            }
        }

        [Category("Grid")]
        public int? XLimit
        {
            get { return _xLimit; }
            set
            {
                _xLimit = value;
                setScrollBars();
                this.Invalidate();
            }
        }

        [Category("Grid")]
        public int? YLimit
        {
            get { return _yLimit; }
            set
            {
                _yLimit = value;
                setScrollBars();
                this.Invalidate();
            }
        }

        private int _cellSize = 20;
        private bool _displayMajorNumbers = true;
        private bool _displayMinorNumbers = false;
        private bool _displayNames = true;
        private Color _majorGridColor = Color.Black;
        private int _majorGridThickness = 5;
        private int _majorGridUnit = 5;
        private Color _minorGridColor = Color.Black;
        private int _minorGridThickness = 1;
        private int _minorGridUnit = 1;
        private int? _xLimit = null;
        private int? _yLimit = null;
        private List<CellInfo> _cells = new List<CellInfo>();

        #endregion Properties

        #region Events

        public delegate void RegionSelectedEventHandler(object sender, SelectionEventArgs e);

        public event RegionSelectedEventHandler CellRegionSelected;

        public event RegionSelectedEventHandler RegionSelected;

        private void GridControl_BackColorChanged(object sender, EventArgs e)
        {
            backBrush = new SolidBrush(this.BackColor);
            this.Invalidate();
        }

        private void GridControl_ForeColorChanged(object sender, EventArgs e)
        {
            foreBrush = new SolidBrush(this.ForeColor);
            this.Invalidate();
        }

        private void GridControl_Load(object sender, EventArgs e)
        {
        }

        private void GridControl_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = e.Location;
        }

        private void GridControl_MouseMove(object sender, MouseEventArgs e)
        {
            curLoc = e.Location;
            if (mouseDown.HasValue)
                this.Invalidate();
        }

        private void GridControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseDown.HasValue && curLoc != mouseDown.Value)
            {
                Rectangle selRegion = new Rectangle();
                selRegion.X = Math.Min(curLoc.X, mouseDown.Value.X);
                selRegion.Y = Math.Min(curLoc.Y, mouseDown.Value.Y);
                selRegion.Width = Math.Max(curLoc.X, mouseDown.Value.X) - selRegion.X;
                selRegion.Height = Math.Max(curLoc.Y, mouseDown.Value.Y) - selRegion.Y;
                RegionSelected?.Invoke(this, new SelectionEventArgs(selRegion));
                Graphics g = this.CreateGraphics();
                int offset = (DisplayMinorNumbers || DisplayMajorNumbers) ? (int)g.MeasureString(Math.Floor(Math.Max(g.VisibleClipBounds.Width, g.VisibleClipBounds.Height) / CellSize).ToString(), this.Font).Width + 5 : (int)Math.Ceiling(thickPen.Width / 2);
                selRegion.X = (int)Math.Floor((selRegion.X - offset) / (decimal)CellSize) + hScroll.Value;
                selRegion.Y = (int)Math.Floor((selRegion.Y - offset) / (decimal)CellSize) + vScroll.Value;
                selRegion.Width = (int)Math.Ceiling((Math.Max(mouseDown.Value.X, curLoc.X) - offset) / (decimal)CellSize) - selRegion.X + hScroll.Value;
                selRegion.Height = (int)Math.Ceiling((Math.Max(mouseDown.Value.Y, curLoc.Y) - offset) / (decimal)CellSize) - selRegion.Y + vScroll.Value;
                Rectangle rect = new Rectangle(0, 0, int.MaxValue, int.MaxValue);
                if (XLimit.HasValue) rect.Width = XLimit.Value;
                if (YLimit.HasValue) rect.Height = YLimit.Value;

                if (rect.IntersectsWith(selRegion))
                    CellRegionSelected?.Invoke(this, new SelectionEventArgs(selRegion));
            }
            mouseDown = null;
            this.Invalidate();
        }

        private void GridControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillRectangle(backBrush, g.VisibleClipBounds);

            //Find offset from 0,0 to draw top/left most point
            int xOffset = 0;
            int yOffset = 0;
            if (DisplayMinorNumbers || DisplayMajorNumbers)
            {
                if (XLimit.HasValue)
                {
                    yOffset = (int)g.MeasureString(XLimit.Value.ToString(), this.Font, 999, new StringFormat(StringFormatFlags.DirectionVertical)).Height + 5;
                }
                else
                {
                    yOffset = (int)g.MeasureString(Math.Floor(Math.Max(g.VisibleClipBounds.Width, g.VisibleClipBounds.Height) / CellSize + hScroll.Value).ToString(), this.Font).Width + 5;
                }
                if (YLimit.HasValue)
                {
                    xOffset = (int)g.MeasureString(YLimit.Value.ToString(), this.Font).Width + 5;
                }
                else
                {
                    xOffset = (int)g.MeasureString(Math.Floor(Math.Max(g.VisibleClipBounds.Width, g.VisibleClipBounds.Height) / CellSize + vScroll.Value).ToString(), this.Font).Width + 5;
                }
            }
            else
            {
                xOffset = (int)Math.Ceiling(thickPen.Width / 2);
                yOffset = xOffset;
            }

            //How Wide and how tall to draw lines
            int maxWidth = (XLimit.HasValue ? CellSize * (XLimit.Value - hScroll.Value) + xOffset : (int)g.VisibleClipBounds.Width);
            if (XLimit.HasValue && Math.Min(XLimit.Value, (g.VisibleClipBounds.Width - xOffset) / CellSize) % MajorGridUnit == 0)
                maxWidth += (int)Math.Ceiling(thickPen.Width / 2);
            else
                maxWidth += 1;
            int maxHeight = (YLimit.HasValue ? CellSize * (YLimit.Value - vScroll.Value) + yOffset : (int)g.VisibleClipBounds.Height) + 1;

            //Fill in colored cells
            if (Cells != null)
            {
                foreach (CellInfo cI in Cells)
                {
                    if (cI == null || cI.CellRegion == null)
                        continue;
                    Rectangle drawRect = new Rectangle();
                    Rectangle tRect = new Rectangle();
                    tRect.X = cI.CellRegion.X - hScroll.Value;
                    tRect.Y = cI.CellRegion.Y - vScroll.Value;
                    tRect.Width = cI.CellRegion.Width;
                    tRect.Height = cI.CellRegion.Height;

                    if (tRect.X < 0)
                    {
                        tRect.Width += tRect.X;
                        tRect.X = 0;
                    }

                    if (tRect.Y < 0)
                    {
                        tRect.Height += tRect.Y;
                        tRect.Y = 0;
                    }

                    if (XLimit.HasValue)
                        tRect.Width = Math.Min(tRect.Width, XLimit.Value - tRect.X);
                    if (YLimit.HasValue)
                        tRect.Height = Math.Min(tRect.Height, YLimit.Value - tRect.Y);

                    if (tRect.Width > 0 && tRect.Height > 0)
                    {
                        drawRect.X = tRect.X * CellSize + xOffset;
                        drawRect.Y = tRect.Y * CellSize + yOffset;
                        drawRect.Width = tRect.Width * CellSize;
                        drawRect.Height = tRect.Height * CellSize;

                        g.FillRectangle(new SolidBrush(cI.Color), drawRect);

                        if (DisplayNames && cI.DisplayName)
                        {
                            SizeF sz = g.MeasureString(cI.Name, this.Font, new SizeF(drawRect.Size));
                            g.DrawString(cI.Name, this.Font, foreBrush, drawRect.X + (drawRect.Width / 2) - (sz.Width / 2), drawRect.Y + (drawRect.Height / 2) - (sz.Height / 2));
                        }
                    }
                }
            }

            int xCellsOnScreen = (int)Math.Ceiling((g.VisibleClipBounds.Width - xOffset) / CellSize);
            int yCellsOnScreen = (int)Math.Ceiling((g.VisibleClipBounds.Width - xOffset) / CellSize);

            int lastCell = Math.Max(
                XLimit.HasValue ? Math.Min(XLimit.Value, xCellsOnScreen) : xCellsOnScreen,
                YLimit.HasValue ? Math.Min(YLimit.Value, yCellsOnScreen) : yCellsOnScreen
                );

            //Draw Grid
            for (int i = 0; i <= lastCell; i++)
            {
                //Lines
                int xVal = i * CellSize + xOffset;
                int yVal = i * CellSize + yOffset;
                if (!XLimit.HasValue || i <= XLimit.Value)
                {
                    if ((i + hScroll.Value) % MajorGridUnit == 0)
                    {
                        g.DrawLine(thickPen, xVal, yOffset, xVal, maxHeight);
                    }
                    else if ((i + hScroll.Value) % MinorGridUnit == 0)
                    {
                        g.DrawLine(thinPen, xVal, yOffset, xVal, maxHeight);
                    }
                }
                if (!YLimit.HasValue || i <= YLimit.Value)
                {
                    if ((i + vScroll.Value) % MajorGridUnit == 0)
                    {
                        g.DrawLine(thickPen, xOffset - (int)Math.Floor(thickPen.Width / 2), yVal, maxWidth, yVal);
                    }
                    else if ((i + vScroll.Value) % MinorGridUnit == 0)
                    {
                        g.DrawLine(thinPen, xOffset, yVal, maxWidth - 1, yVal);
                    }
                }

                //Numbers
                if (((DisplayMajorNumbers && (i + hScroll.Value) % MajorGridUnit == 0) || (DisplayMinorNumbers && (i + hScroll.Value) % MinorGridUnit == 0)) && (!XLimit.HasValue || (i + hScroll.Value) <= XLimit.Value))
                {
                    SizeF sz = g.MeasureString((i + hScroll.Value).ToString(), this.Font, yOffset, new StringFormat(StringFormatFlags.DirectionVertical));
                    g.DrawString((i + hScroll.Value).ToString(), this.Font, this.foreBrush, i * CellSize + xOffset - sz.Width / 2, yOffset - sz.Height - 5, new StringFormat(StringFormatFlags.DirectionVertical));
                }
                if (((DisplayMajorNumbers && (i + vScroll.Value) % MajorGridUnit == 0) || (DisplayMinorNumbers && (i + vScroll.Value) % MinorGridUnit == 0)) && (!YLimit.HasValue || (i + vScroll.Value) <= YLimit.Value))
                {
                    SizeF sz = g.MeasureString((i + vScroll.Value).ToString(), this.Font);
                    g.DrawString((i + vScroll.Value).ToString(), this.Font, this.foreBrush, xOffset - sz.Width - 5, i * CellSize + yOffset - sz.Height / 2);
                }
            }

            //if (xCellCount % MajorGridUnit == 0)
            //{
            //    if (YLimit.HasValue && YLimit.Value % MajorGridThickness == 0)
            //    {
            //        if (!XLimit.HasValue || xCellCount <= XLimit.Value)
            //            g.DrawLine(thickPen, i, yOffset - (int)Math.Floor(thickPen.Width / 2), i, maxHeight + (int)Math.Ceiling(thickPen.Width / 2));
            //    }
            //    else
            //    {
            //        if (!XLimit.HasValue || xCellCount <= XLimit.Value)
            //            g.DrawLine(thickPen, i, yOffset - (int)Math.Floor(thickPen.Width / 2), i, maxHeight);
            //    }

            //    if (DisplayMajorNumbers)
            //    {
            //        if (!XLimit.HasValue || (XLimit.HasValue && xCellCount <= XLimit.Value))
            //        {
            //            SizeF sz = g.MeasureString(xCellCount.ToString(), this.Font, yOffset, new StringFormat(StringFormatFlags.DirectionVertical));
            //            g.DrawString(xCellCount.ToString(), this.Font, foreBrush, i - sz.Width / 2, yOffset - sz.Height - 5, new StringFormat(StringFormatFlags.DirectionVertical));
            //        }
            //    }
            //    xCellCount++;
            //}
            //else if (xCellCount % MinorGridUnit == 0)
            //{
            //    if (!XLimit.HasValue || xCellCount <= XLimit.Value)
            //        g.DrawLine(thinPen, i, yOffset, i, maxHeight);

            //    if (DisplayMinorNumbers)
            //    {
            //        if (!XLimit.HasValue || (XLimit.HasValue && xCellCount <= XLimit.Value))
            //        {
            //            SizeF sz = g.MeasureString(xCellCount.ToString(), this.Font, yOffset, new StringFormat(StringFormatFlags.DirectionVertical));
            //            g.DrawString(xCellCount.ToString(), this.Font, foreBrush, i - sz.Width / 2, yOffset - sz.Height - 5, new StringFormat(StringFormatFlags.DirectionVertical));
            //        }
            //    }
            //    xCellCount++;
            //}

            //if (yCellCount % MajorGridUnit == 0)
            //{
            //    if (!YLimit.HasValue || yCellCount <= YLimit.Value)
            //        g.DrawLine(thickPen, xOffset, i, maxWidth, i);

            //    if (DisplayMajorNumbers)
            //    {
            //        if (!YLimit.HasValue || (YLimit.HasValue && yCellCount <= YLimit.Value))
            //        {
            //            SizeF sz = g.MeasureString(yCellCount.ToString(), this.Font);
            //            g.DrawString(yCellCount.ToString(), this.Font, foreBrush, xOffset - sz.Width - 5, i - (sz.Height / 2));
            //        }
            //    }
            //    yCellCount++;
            //}
            //else if (yCellCount % MinorGridUnit == 0)
            //{
            //    if (!YLimit.HasValue || yCellCount <= YLimit.Value)
            //        g.DrawLine(thinPen, xOffset, i, maxWidth, i);

            //    if (DisplayMinorNumbers)
            //    {
            //        if (!YLimit.HasValue || (YLimit.HasValue && yCellCount <= YLimit.Value))
            //        {
            //            SizeF sz = g.MeasureString(yCellCount.ToString(), this.Font);
            //            g.DrawString(yCellCount.ToString(), this.Font, foreBrush, xOffset - sz.Width - 5, i - (sz.Height / 2));
            //        }
            //    }
            //    yCellCount++;
            //}
            //}

            //Draw rubberband box
            if (mouseDown.HasValue && curLoc != mouseDown.Value)
            {
                drawRubberBandBox(g);
            }

            g.ResetClip();
            g.SetClip(g.VisibleClipBounds);
        }

        private void GridControl_Resize(object sender, EventArgs e)
        {
            setScrollBars();
        }

        #endregion Events

        private void drawRubberBandBox(Graphics g)
        {
            int offset = (int)(highlightPen.Width / 2);
            Rectangle drawRect = new Rectangle();
            drawRect.X = Math.Min(mouseDown.Value.X, curLoc.X) + offset;
            drawRect.Y = Math.Min(mouseDown.Value.Y, curLoc.Y) + offset;
            drawRect.Width = Math.Max(mouseDown.Value.X, curLoc.X) - drawRect.X - offset * 2;
            drawRect.Height = Math.Max(mouseDown.Value.Y, curLoc.Y) - drawRect.Y - offset * 2;
            g.FillRectangle(highlightBrush, drawRect);
            g.DrawRectangle(highlightPen, drawRect.X - offset, drawRect.Y - offset, drawRect.Width + offset * 2, drawRect.Height + offset * 2);
        }

        private void setScrollBars()
        {
            Graphics g = this.CreateGraphics();
            int offset = (DisplayMinorNumbers || DisplayMajorNumbers) ? (int)g.MeasureString(Math.Floor(Math.Max(g.VisibleClipBounds.Width, g.VisibleClipBounds.Height) / CellSize).ToString(), this.Font).Width + 5 : (int)Math.Ceiling(thickPen.Width / 2);
            if (!XLimit.HasValue)
            {
                hScroll.Maximum = (Math.Max(hScroll.Value + hScroll.LargeChange, Cells.Count > 0 ? Cells.Max(cI => cI.CellRegion.X + cI.CellRegion.Width) : 0)) + MajorGridUnit - hScroll.Maximum % MajorGridUnit + hScroll.LargeChange;

                hScroll.Visible = true;
            }
            else
            {
                int cellsOnScreen = (int)Math.Floor(((g.VisibleClipBounds.Width - offset) / CellSize));
                if (cellsOnScreen >= XLimit.Value)
                {
                    hScroll.Visible = false;
                }
                else
                {
                    hScroll.Visible = true;
                    hScroll.Maximum = (XLimit.Value - cellsOnScreen) + MajorGridUnit - hScroll.Maximum % MajorGridUnit + hScroll.LargeChange;
                }
            }

            if (!YLimit.HasValue)
            {
                vScroll.Maximum = Math.Max(vScroll.Value + MajorGridUnit + MinorGridUnit, Cells.Count > 0 ? Cells.Max(cI => cI.CellRegion.Y + cI.CellRegion.Height) : 0);
            }
            else
            {
                int cellsOnScreen = (int)Math.Floor(((g.VisibleClipBounds.Height - offset) / CellSize));
                if (cellsOnScreen >= YLimit.Value)
                {
                    vScroll.Visible = false;
                }
                else
                {
                    vScroll.Visible = true;
                    vScroll.Maximum = YLimit.Value - cellsOnScreen;
                }
            }
        }

        private new void Scroll(Object sender, EventArgs e)
        {
            setScrollBars();
            this.Invalidate();
        }
    }
}