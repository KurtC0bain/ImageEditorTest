namespace ConsoleWpfAppTest;

internal static class ThreadHelpers
{
    public static Thread FromSta(Action action, bool wait = true)
    {
        var thread = new Thread(new ThreadStart(action));
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();

        if (wait)
        {
            thread.Join();
        }

        return thread;
    }
}
