namespace Serilog.Sinks.EventBag.Tests
{
    public class ClassUsingLogger
    {
        private readonly ILogger _logger;
        public ClassUsingLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void LogTwoEntries()
        {
            _logger.Information("Start");
            _logger.Information("End");
        }
    }
}
