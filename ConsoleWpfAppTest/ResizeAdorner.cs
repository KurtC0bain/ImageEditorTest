using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;

namespace ConsoleWpfAppTest;

public class ResizeAdorner : Adorner
{
    private const int CornerRectSize = 8;
    private readonly Brush CornerRectColor = Brushes.Coral;
    private readonly Brush RectColor = Brushes.Coral;

    private readonly VisualCollection _adornerVisuals;
    private readonly Thumb _thumb1;
    private readonly Thumb _thumb2;
    private readonly Rectangle _rec;

    public ResizeAdorner(UIElement adornedElement) : base(adornedElement)
    {
        _adornerVisuals = new VisualCollection(this);
        _thumb1 = new Thumb { Background = CornerRectColor, Height = CornerRectSize, Width = CornerRectSize };
        _thumb2 = new Thumb { Background = CornerRectColor, Height = CornerRectSize, Width = CornerRectSize };
        _rec = new Rectangle { Stroke = RectColor, StrokeThickness = 2 }; // , StrokeDashArray = { 3, 2 }

        _thumb1.DragDelta += Thumb1_DragDelta;
        _thumb2.DragDelta += Thumb2_DragDelta;

        _adornerVisuals.Add(_rec);
        _adornerVisuals.Add(_thumb1);
        _adornerVisuals.Add(_thumb2);
    }


    private void Thumb1_DragDelta(object sender, DragDeltaEventArgs e)
    {
        var element = (FrameworkElement)AdornedElement;
        element.Height = element.Height - e.VerticalChange < 0 ? 0 : element.Height - e.VerticalChange;

        element.Width = element.Width - e.HorizontalChange < 0 ? 0 : element.Width - e.HorizontalChange;
    }

    private void Thumb2_DragDelta(object sender, DragDeltaEventArgs e)
    {
        var element = (FrameworkElement)AdornedElement;
        element.Height = element.Height + e.VerticalChange < 0 ? 0 : element.Height + e.VerticalChange;

        element.Width = element.Width + e.HorizontalChange < 0 ? 0 : element.Width + e.HorizontalChange;
    }


    protected override Visual GetVisualChild(int index) => _adornerVisuals[index];

    protected override int VisualChildrenCount => _adornerVisuals.Count;

    protected override Size ArrangeOverride(Size finalSize)
    {
        _rec.Arrange(new Rect(-2.5, -2.5, AdornedElement.DesiredSize.Width + 5, AdornedElement.DesiredSize.Height + 5));
        _thumb1.Arrange(new Rect(-5, -5, 10, 10));
        _thumb2.Arrange(new Rect(AdornedElement.DesiredSize.Width - 5, AdornedElement.DesiredSize.Height - 5, 10, 10));

        return base.ArrangeOverride(finalSize);
    }
}
