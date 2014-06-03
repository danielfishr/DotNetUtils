namespace DotNetUtils
{
    using System.Diagnostics;

    public static class StartedStopwatch
    {
        public static Stopwatch New
        {
            get
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                return stopwatch;
            }
        }
    }
}