using System.Collections.Generic;

namespace MvvX.Plugins.HockeyApp.MoqUnitTest
{
    public class MoqHockeyAppEvent
    {
        /// <summary>
        /// Current event name
        /// </summary>
        public string EventName { get; set; }
        
        /// <summary>
        /// Public properties
        /// </summary>
        public IDictionary<string, string> Properties { get; set; }

        /// <summary>
        /// Custom metrics
        /// </summary>
        public IDictionary<string, double> Metrics { get; set; }
    }
}
