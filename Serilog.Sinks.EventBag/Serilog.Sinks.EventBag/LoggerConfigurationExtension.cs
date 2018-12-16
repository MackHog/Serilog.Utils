using System.Collections.Concurrent;
using Serilog.Configuration;
using Serilog.Events;

namespace Serilog.Sinks.EventBag
{
    public static class LoggerConfigurationExtension
    {
        public static LoggerConfiguration EventBag(
            this LoggerSinkConfiguration sinkConfiguration, ConcurrentBag<LogEvent> eventBag)
        {
            return sinkConfiguration.Sink(new EventBag(eventBag));
        }
    }
}