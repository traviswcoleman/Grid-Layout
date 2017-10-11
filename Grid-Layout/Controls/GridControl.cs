using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grid_Layout.Controls
{
    public partial class GridControl : UserControl
    {
        #region Classes

        [Serializable]
        public class CellInfo
        {
            public Rectangle CellRegion { get; set; }

            public Color Color { get; set; }

            public bool DisplayName { get; set; }

            public string Name { get; set; }

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
        }

        public class SelectionEventArgs : EventArgs
        {
            public Rectangle SelectedRegion { get; set; }

            public SelectionEventArgs(Rectangle SelectedRegion)
            {
                this.SelectedRegion = SelectedRegion;
            }
        }

        #endregion Classes

        private List<CellInfo> _cells = new List<CellInfo>();
        private Pen thickPen = new Pen(Brushes.Black, 5);
        private Pen thinPen = new Pen(Brushes.Black, 1);
        private Brush backBrush;
        private Brush foreBrush;
        private Point? mouseDown = null;
        private Point curLoc = new Point(0, 0);
        private Brush highlightBrush;
        private Pen highlightPen;

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

        private bool _displayNames = true;

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

        private bool _displayMinorNumbers = false;

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

        private bool _displayMajorNumbers = true;

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

        private int? _xLimit = null;

        [Category("Grid")]
        public int? XLimit
        {
            get { return _xLimit; }
            set
            {
                _xLimit = value;
                hScroll.Visible = (!_xLimit.HasValue || _xLimit.Value * CellSize > this.Width);
                this.Invalidate();
            }
        }

        private int? _yLimit = null;

        [Category("Grid")]
        public int? YLimit
        {
            get { return _yLimit; }
            set
            {
                _yLimit = value;
                vScroll.Visible = (!_yLimit.HasValue || _yLimit.Value * CellSize > this.Height);
                this.Invalidate();
            }
        }

        private int? _majorGridUnit = 5;

        [DefaultValue(5)]
        [Category("Grid")]
        public int? MajorGridUnit
        {
            get { return _majorGridUnit; }
            set
            {
                _majorGridUnit = value;
                this.Invalidate();
            }
        }

        private int _majorGridThickness = 5;

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

        private Color _majorGridColor = Color.Black;

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

        private int? _minorGridUnit = 1;

        [DefaultValue(1)]
        [Category("Grid")]
        public int? MinorGridUnit
        {
            get { return _minorGridUnit; }
            set
            {
                _minorGridUnit = value;
                this.Invalidate();
            }
        }

        private int _minorGridThickness = 1;

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

        private Color _minorGridColor = Color.Black;

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

        private int _cellSize = 20;

        [DefaultValue(20)]
        [Category("Grid")]
        public int CellSize
        {
            get { return _cellSize; }
            set
            {
                _cellSize = value;
                this.Invalidate();
            }
        }

        #endregion Properties

        public GridControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            backBrush = new SolidBrush(this.BackColor);
            foreBrush = new SolidBrush(this.ForeColor);

            highlightBrush = new SolidBrush(Color.FromArgb(80, Color.Blue));
            highlightPen = new Pen(Color.FromArgb(160, Color.Blue), 5);

            this.BackColorChanged += GridControl_BackColorChanged;
            this.ForeColorChanged += GridControl_ForeColorChanged;
            this.MouseDown += GridControl_MouseDown;
            this.MouseUp += GridControl_MouseUp;
            this.MouseMove += GridControl_MouseMove;
        }

        #region Events

        public delegate void RegionSelectedEventHandler(object sender, SelectionEventArgs e);

        public event RegionSelectedEventHandler RegionSelected;

        public event RegionSelectedEventHandler CellRegionSelected;

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
                selRegion.X = (int)Math.Floor((selRegion.X - offset) / (decimal)CellSize);
                selRegion.Y = (int)Math.Floor((selRegion.Y - offset) / (decimal)CellSize);
                selRegion.Width = (int)Math.Ceiling((Math.Max(mouseDown.Value.X, curLoc.X) - offset) / (decimal)CellSize) - selRegion.X;
                selRegion.Height = (int)Math.Ceiling((Math.Max(mouseDown.Value.Y, curLoc.Y) - offset) / (decimal)CellSize) - selRegion.Y;
                CellRegionSelected?.Invoke(this, new SelectionEventArgs(selRegion));
            }
            mouseDown = null;
            this.Invalidate();
        }

        private void GridControl_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = e.Location;
        }

        private void GridControl_Load(object sender, EventArgs e)
        {
        }

        private void GridControl_ForeColorChanged(object sender, EventArgs e)
        {
            foreBrush = new SolidBrush(this.ForeColor);
            this.Invalidate();
        }

        private void GridControl_BackColorChanged(object sender, EventArgs e)
        {
            backBrush = new SolidBrush(this.BackColor);
            this.Invalidate();
        }

        private void GridControl_Paint(object sender, PaintEventArgs e)
        {
            int cellCount = 0;
            Graphics g = e.Graphics;

            g.FillRectangle(backBrush, g.VisibleClipBounds);

            //Find offset from 0,0 to draw top/left most point
            int offset = (DisplayMinorNumbers || DisplayMajorNumbers) ? (int)g.MeasureString(Math.Floor(Math.Max(g.VisibleClipBounds.Width, g.VisibleClipBounds.Height) / CellSize).ToString(), this.Font).Width + 5 : (int)Math.Ceiling(thickPen.Width / 2);

            //How Wide and how tall to draw lines
            int maxWidth = XLimit.HasValue ? CellSize * XLimit.Value + offset : (int)g.VisibleClipBounds.Width;
            int maxHeight = YLimit.HasValue ? CellSize * YLimit.Value + offset : (int)g.VisibleClipBounds.Height;

            //Fill in colored cells
            if (Cells != null)
            {
                foreach (CellInfo cI in Cells)
                {
                    if (cI == null || cI.CellRegion == null)
                        continue;
                    Rectangle drawRect = new Rectangle();
                    drawRect.X = cI.CellRegion.X * CellSize + offset;
                    drawRect.Y = cI.CellRegion.Y * CellSize + offset;
                    drawRect.Width = cI.CellRegion.Width * CellSize;
                    drawRect.Height = cI.CellRegion.Height * CellSize;

                    g.FillRectangle(new SolidBrush(cI.Color), drawRect);

                    if (DisplayNames && cI.DisplayName)
                    {
                        SizeF sz = g.MeasureString(cI.Name, this.Font, new SizeF(drawRect.Size));
                        g.DrawString(cI.Name, this.Font, foreBrush, drawRect.X + (drawRect.Width / 2) - (sz.Width / 2), drawRect.Y + (drawRect.Height / 2) - (sz.Height / 2));
                    }
                }
            }

            //Draw Grid
            for (int i = offset; i <= Math.Max(g.VisibleClipBounds.Width, g.VisibleClipBounds.Height); i += CellSize)
            {
                if (cellCount % MajorGridUnit == 0)
                {
                    if (YLimit.HasValue && YLimit.Value % MajorGridThickness == 0)
                    {
                        if (!XLimit.HasValue || cellCount <= XLimit.Value)
                            g.DrawLine(thickPen, i, offset - (int)Math.Floor(thickPen.Width / 2), i, maxHeight + (int)Math.Ceiling(thickPen.Width / 2));
                    }
                    else
                    {
                        if (!XLimit.HasValue || cellCount <= XLimit.Value)
                            g.DrawLine(thickPen, i, offset - (int)Math.Floor(thickPen.Width / 2), i, maxHeight);
                    }
                    if (!YLimit.HasValue || cellCount <= YLimit.Value)
                        g.DrawLine(thickPen, offset, i, maxWidth, i);

                    if (DisplayMajorNumbers)
                    {
                        if (!YLimit.HasValue || (YLimit.HasValue && cellCount <= YLimit.Value))
                        {
                            SizeF sz = g.MeasureString(cellCount.ToString(), this.Font);
                            g.DrawString(cellCount.ToString(), this.Font, foreBrush, offset - sz.Width - 5, i - (sz.Height / 2));
                        }
                        if (!XLimit.HasValue || (XLimit.HasValue && cellCount <= XLimit.Value))
                        {
                            SizeF sz = g.MeasureString(cellCount.ToString(), this.Font, offset, new StringFormat(StringFormatFlags.DirectionVertical));
                            g.DrawString(cellCount.ToString(), this.Font, foreBrush, i - sz.Width / 2, offset - sz.Height - 5, new StringFormat(StringFormatFlags.DirectionVertical));
                        }
                    }
                }
                else if (cellCount % MinorGridUnit == 0)
                {
                    if (!XLimit.HasValue || cellCount <= XLimit.Value)
                        g.DrawLine(thinPen, i, offset, i, maxHeight);
                    if (!YLimit.HasValue || cellCount <= YLimit.Value)
                        g.DrawLine(thinPen, offset, i, maxWidth, i);

                    if (DisplayMinorNumbers)
                    {
                        if (!YLimit.HasValue || (YLimit.HasValue && cellCount <= YLimit.Value))
                        {
                            SizeF sz = g.MeasureString(cellCount.ToString(), this.Font);
                            g.DrawString(cellCount.ToString(), this.Font, foreBrush, offset - sz.Width - 5, i - (sz.Height / 2));
                        }
                        if (!XLimit.HasValue || (XLimit.HasValue && cellCount <= XLimit.Value))
                        {
                            SizeF sz = g.MeasureString(cellCount.ToString(), this.Font, offset, new StringFormat(StringFormatFlags.DirectionVertical));
                            g.DrawString(cellCount.ToString(), this.Font, foreBrush, i - sz.Width / 2, offset - sz.Height - 5, new StringFormat(StringFormatFlags.DirectionVertical));
                        }
                    }
                }
                cellCount++;
            }

            //Draw rubberband box
            if (mouseDown.HasValue && curLoc != mouseDown.Value)
            {
                drawRubberBandBox(g);
            }

            g.ResetClip();
            g.SetClip(g.VisibleClipBounds);
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

        private void GridControl_Resize(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            hScroll.Visible = (!XLimit.HasValue || XLimit.Value * CellSize > g.VisibleClipBounds.Width - vScroll.Width);

            vScroll.Visible = (!YLimit.HasValue || YLimit.Value * CellSize > g.VisibleClipBounds.Height - hScroll.Height);

        }
    }
}