using System.Collections.Generic;

namespace MvvX.Plugins.HockeyApp.MoqUnitTest
{
    public class MoqHockeyAppTrace
    {
        /// <summary>
        /// Custom message
        /// </summary>
        public string Message { get; set; } 

        /// <summary>
        /// Security level
        /// </summary>
        public SeverityLevel SeverityLevel { get; set; }

        /// <summary>
        /// Xustom properties
        /// </summary>
        public IDictionary<string, string> Properties { get; set; }
    }
}
