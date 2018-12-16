using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog.Events;
using System.Collections.Concurrent;
using System.Linq;

namespace Serilog.Sinks.EventBag.Tests
{
    [TestClass]
    public class EventBagTests
    {
        [TestMethod]
        public void When_Log_Entries_Are_Added_EventBag_Should_Contain_All()
        {
            //arrange
            var contextKey = "contextKey";
            var contextValue = "contextValue";
            var eventBag = new ConcurrentBag<LogEvent>();
            var loggerInstance = new LoggerConfiguration()
                    .WriteTo.EventBag(eventBag)
                    .CreateLogger();
            var logger = loggerInstance.ForContext(contextKey, contextValue);
            var classUsingLogger = new ClassUsingLogger(logger);

            //act
            classUsingLogger.LogTwoEntries();

            //arrange
            Assert.IsTrue(eventBag.Any());
            Assert.AreEqual(eventBag.Count, 2);
            foreach (var logEvent in eventBag)
            {
                Assert.IsTrue(logEvent.Properties.Any(p => p.Key == contextKey));
                Assert.IsTrue(logEvent.Properties.First(p => p.Key == contextKey).Value.ToString().Contains(contextValue));
            }
        }
    }
}
