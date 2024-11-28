using System;
using System.Drawing;
using System.Windows.Forms;

public class ThemedScrollBar : Control
{
    private int _maximum = 100;
    private int _minimum = 0;
    private int _value = 0;
    private int _largeChange = 10;

    private bool _isDragging = false;
    private Point _dragStartPoint;
    private int _dragStartValue;

    public Color TrackColor { get; set; } = Color.FromArgb(50, 50, 50); // Default track color
    public Color ThumbColor { get; set; } = Color.FromArgb(229, 152, 102); // Default thumb color
    public Color BorderColor { get; set; } = Color.FromArgb(45, 45, 45); // Default border color

    public int Maximum
    {
        get => _maximum;
        set
        {
            if (value < _minimum) throw new ArgumentException("Maximum must be greater than or equal to Minimum.");
            _maximum = value;
            Invalidate();
        }
    }

    public int Minimum
    {
        get => _minimum;
        set
        {
            if (value > _maximum) throw new ArgumentException("Minimum must be less than or equal to Maximum.");
            _minimum = value;
            Invalidate();
        }
    }

    public int Value
    {
        get => _value;
        set
        {
            _value = Math.Max(_minimum, Math.Min(_maximum, value));
            Invalidate();
            OnScroll(new ScrollEventArgs(ScrollEventType.ThumbTrack, _value));
        }
    }

    public int LargeChange
    {
        get => _largeChange;
        set
        {
            if (value < 1) throw new ArgumentException("LargeChange must be greater than 0.");
            _largeChange = value;
            Invalidate();
        }
    }

    public event ScrollEventHandler Scroll;

    public ThemedScrollBar()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        Size = new Size(20, 150); // Default size
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        var g = e.Graphics;

        // Draw track
        using (var trackBrush = new SolidBrush(TrackColor))
        {
            g.FillRectangle(trackBrush, ClientRectangle);
        }

        // Calculate thumb size and position
        int thumbHeight = Math.Max(20, (int)((double)LargeChange / Math.Max(1, (Maximum - Minimum + LargeChange)) * Height));
        int thumbPosition = Math.Max(0, Math.Min(Height - thumbHeight, (int)((double)(Value - Minimum) / (Maximum - Minimum) * (Height - thumbHeight))));

        // Draw thumb
        var thumbRect = new Rectangle(1, thumbPosition, Width - 2, thumbHeight);
        using (var thumbBrush = new SolidBrush(ThumbColor))
        {
            g.FillRectangle(thumbBrush, thumbRect);
        }

        // Draw border
        using (var borderPen = new Pen(BorderColor))
        {
            g.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        int thumbHeight = Math.Max(20, (int)((double)LargeChange / Math.Max(1, (Maximum - Minimum + LargeChange)) * Height));
        int thumbPosition = Math.Max(0, Math.Min(Height - thumbHeight, (int)((double)(Value - Minimum) / (Maximum - Minimum) * (Height - thumbHeight))));
        var thumbRect = new Rectangle(1, thumbPosition, Width - 2, thumbHeight);

        if (thumbRect.Contains(e.Location))
        {
            _isDragging = true;
            _dragStartPoint = e.Location;
            _dragStartValue = Value;
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        if (_isDragging)
        {
            int deltaY = e.Location.Y - _dragStartPoint.Y;
            int thumbHeight = Math.Max(20, (int)((double)LargeChange / Math.Max(1, (Maximum - Minimum + LargeChange)) * Height));
            int trackHeight = Math.Max(1, Height - thumbHeight);
            double valuePerPixel = (double)(Maximum - Minimum) / trackHeight;

            Value = Math.Max(Minimum, Math.Min(Maximum, _dragStartValue + (int)(deltaY * valuePerPixel)));
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);

        if (_isDragging)
        {
            _isDragging = false;
            OnScroll(new ScrollEventArgs(ScrollEventType.EndScroll, Value));
        }
    }

    protected virtual void OnScroll(ScrollEventArgs e)
    {
        Scroll?.Invoke(this, e);
    }
}
