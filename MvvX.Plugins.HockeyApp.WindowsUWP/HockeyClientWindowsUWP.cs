using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.HockeyApp;

namespace MvvX.Plugins.HockeyApp.WindowsUWP
{
    public class HockeyClientWindowsUWP : IHockeyClient
    {
        private bool activateMetrics;
        private bool activateCrashReports;

        public void Configure(string identifier, string version, bool activateTelemetry, bool activateMetrics, bool activateCrashReports)
        {
            HockeyClient.Current.Configure(identifier);
            this.activateMetrics = activateMetrics;
            this.activateCrashReports = activateCrashReports;
        }

        public void Flush()
        {
            HockeyClient.Current.Flush();
        }

        public void TrackEvent(string eventName)
        {
            if (activateMetrics)
                HockeyClient.Current.TrackEvent(eventName);
        }

        public void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            HockeyClient.Current.TrackEvent(eventName, properties, metrics);
        }

        public void TrackException(Exception ex, IDictionary<string, string> properties = null)
        {
            if(activateCrashReports)
                HockeyClient.Current.TrackException(ex, properties);
        }

        public void TrackMetric(string name, double value, IDictionary<string, string> properties = null)
        {
            if(activateMetrics)
                HockeyClient.Current.TrackMetric(name, value, properties);
        }

        public void TrackPageView(string name)
        {
            HockeyClient.Current.TrackPageView(name);
        }

        public void TrackTrace(string message)
        {
            HockeyClient.Current.TrackTrace(message);
        }

        public void TrackTrace(string message, IDictionary<string, string> properties)
        {
            HockeyClient.Current.TrackTrace(message, properties);
        }

        public void TrackTrace(string message, SeverityLevel severityLevel)
        {
            HockeyClient.Current.TrackTrace(message, (Microsoft.HockeyApp.SeverityLevel)(int)severityLevel);
        }

        public void TrackTrace(string message, SeverityLevel severityLevel, IDictionary<string, string> properties)
        {
            HockeyClient.Current.TrackTrace(message, (Microsoft.HockeyApp.SeverityLevel)(int)severityLevel, properties);
        }

        public async Task SendCrashesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendFeedbackAsync(string message, string email, string subject, string name, IList<IHockeyAppAttachment> files)
        {
            throw new NotImplementedException();
        }
    }
}
