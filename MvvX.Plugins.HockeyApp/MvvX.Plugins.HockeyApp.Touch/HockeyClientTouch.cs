using System;
using System.Collections.Generic;
using HockeyApp.iOS;

namespace MvvX.Plugins.HockeyApp.Touch
{
    public class HockeyClientTouch : IHockeyClient
    {
        public void Configure(string identifier, bool activateMetrics, bool activateCrashReports)
        {
            var manager = BITHockeyManager.SharedHockeyManager;
            manager.Configure(identifier);
            manager.DisableCrashManager = !activateCrashReports;
            manager.DisableMetricsManager = !activateMetrics;
            manager.StartManager();
        }

        public void Flush()
        {
            throw new NotImplementedException();
        }

        public void TrackEvent(string eventName)
        {
            BITHockeyManager.SharedHockeyManager.MetricsManager.TrackEvent(eventName);
        }

        public void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            BITHockeyManager.SharedHockeyManager.MetricsManager.TrackEvent(eventName);
        }

        public void TrackException(Exception ex, IDictionary<string, string> properties = null)
        {
            throw new NotImplementedException();
        }

        public void TrackMetric(string name, double value, IDictionary<string, string> properties = null)
        {
            throw new NotImplementedException();
        }

        public void TrackPageView(string name)
        {
            throw new NotImplementedException();
        }

        public void TrackTrace(string message)
        {
            throw new NotImplementedException();
        }

        public void TrackTrace(string message, IDictionary<string, string> properties)
        {
            throw new NotImplementedException();
        }

        public void TrackTrace(string message, SeverityLevel severityLevel)
        {
            throw new NotImplementedException();
        }

        public void TrackTrace(string message, SeverityLevel severityLevel, IDictionary<string, string> properties)
        {
            throw new NotImplementedException();
        }
    }
}
