namespace ImageEditorTest.Extensions
{
    public static class ControlExtensions
    {
        private static readonly Dictionary<Control, bool> draggables = new();
        private static Size mouseOffset;


        public static void Draggable(this Control control, bool enable = true)
        {
            if (enable)
            {
                if (!draggables.ContainsKey(control))
                {
                    draggables.Add(control, false);
                    control.MouseDown += Control_MouseDown;
                    control.MouseUp += Control_MouseUp;
                    control.MouseMove += Control_MouseMove;
                }
            }
            else if (draggables.ContainsKey(control))
            {
                control.MouseDown -= Control_MouseDown;
                control.MouseUp -= Control_MouseUp;
                control.MouseMove -= Control_MouseMove;
                draggables.Remove(control);
            }
        }


        private static void Control_MouseDown(object? sender, MouseEventArgs e)
        {
            mouseOffset = new Size(e.Location);
            draggables[(Control)sender!] = true;
        }


        private static void Control_MouseUp(object? sender, MouseEventArgs e)
        {
            draggables[(Control)sender!] = false;
        }


        private static void Control_MouseMove(object? sender, MouseEventArgs e)
        {
            checked
            {
                if (draggables[(Control)sender!])
                {
                    Point point = e.Location - mouseOffset;
                    ((Control)sender!).Left += point.X;
                    ((Control)sender).Top += point.Y;
                }
            }
        }

    }
}
