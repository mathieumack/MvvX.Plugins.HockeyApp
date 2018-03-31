using System.Collections.Generic;

namespace MvvX.Plugins.HockeyApp.MoqUnitTest
{
    public class MoqHockeyAppMetrics
    {
        /// <summary>
        /// Current name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Current value
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Public properties
        /// </summary>
        public IDictionary<string, string> Properties { get; set; }
    }
}
