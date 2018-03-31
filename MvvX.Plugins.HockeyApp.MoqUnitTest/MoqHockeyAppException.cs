using System;
using System.Collections.Generic;
using System.Text;

namespace MvvX.Plugins.HockeyApp.MoqUnitTest
{
    public class MoqHockeyAppException
    {
        /// <summary>
        /// Current exception
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Custom properties
        /// </summary>
        public IDictionary<string, string> Properties { get; set; }
    }
}
