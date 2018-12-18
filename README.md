# Serilog.Utils
Utils for the logging framework Serilog

## Serilog.Sinks.EventBag
Write log events to an in-memory event bag. Perfect for unit testing where you need to verify the loggin output and context properties 

### Example

Setup the loggin instance

```
var eventBag = new ConcurrentBag<LogEvent>();
var logger = new LoggerConfiguration()
		.WriteTo.EventBag(eventBag)
		.CreateLogger();
```
Add context variable
```
var logger = loggerInstance.ForContext("contextKey", "contextValue");
```
Add some logging
```
logger.Information("Start");
logger.Information("End");
```

Then verify the events in the eventBag

```
Assert.IsTrue(eventBag.Any());
Assert.AreEqual(eventBag.Count, 2);
foreach (var logEvent in eventBag)
{
	Assert.IsTrue(logEvent.Properties.Any(p => p.Key == "contextKey"));
	Assert.IsTrue(logEvent.Properties.First(p => p.Key == "contextKey").Value.ToString().Contains("contextValue"));
}
```
