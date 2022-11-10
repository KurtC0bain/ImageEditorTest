namespace ImageEditorTest
{
    internal class Win32Window : IWin32Window
    {
        private readonly Form _form;

        public Win32Window(Form form)
        {
            _form = form;
        }

        public IntPtr Handle => _form.Handle;
    }

    internal static class FormExtensions
    {
        public static IWin32Window AsWin32Window(this Form form) => new Win32Window(form);
    }
}
