using Serilog.Core;
using Serilog.Events;
using System.Collections.Concurrent;

namespace Serilog.Sinks.EventBag
{
    public class EventBag : ILogEventSink
    {
        private readonly ConcurrentBag<LogEvent> _eventBag;
        public EventBag(ConcurrentBag<LogEvent> eventBag)
        {
            _eventBag = eventBag;
        }

        public void Emit(LogEvent logEvent)
        {
            _eventBag.Add(logEvent);
        }
    }
}