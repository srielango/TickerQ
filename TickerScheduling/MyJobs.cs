using TickerQ.Utilities.Base;

namespace TickerScheduling
{
    public class MyJobs
    {
        private readonly ILogger<MyJobs> _logger;

        public MyJobs(ILogger<MyJobs> logger)
        {
            _logger = logger;
        }

        [TickerFunction("CleanupLogs")]
        public void CleanUpLogs()
        {
            _logger.LogWarning("Cleaning up logs...");
        }
    }
}
