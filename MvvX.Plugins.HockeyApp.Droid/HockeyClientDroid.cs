using System;
using System.Collections.Generic;
using HockeyApp.Android;
using HockeyApp.Android.Metrics;
using Android.App;
using Android.Content;
using System.Threading.Tasks;

namespace MvvX.Plugins.HockeyApp.Droid
{
    public class HockeyClientDroid : IHockeyClient
    {
        #region Fields

        private readonly Context context;
        private readonly Application application;

        #endregion

        #region Constructor

        public HockeyClientDroid(Context context, Application application)
        {
            this.context = context;
            this.application = application;
        }

        #endregion

        private string identifier = null;
        private bool isConfigured = false;

        public void Configure(string identifier, string version, bool activateTelemetry, bool activateMetrics, bool activateCrashReports)
        {
            this.identifier = identifier;
            if(activateCrashReports)
                CrashManager.Register(context, this.identifier);
            if(activateMetrics)
                MetricsManager.Register(this.context, this.application, this.identifier);

            isConfigured = true;
        }

        public void Flush()
        {
            throw new NotImplementedException();
        }

        public void TrackEvent(string eventName)
        {
            // Check metrics activation :
            if (MetricsManager.IsUserMetricsEnabled)
                MetricsManager.TrackEvent(eventName);
        }

        public void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            // Check metrics activation :
            if (MetricsManager.IsUserMetricsEnabled)
                MetricsManager.TrackEvent(eventName);
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

        public async Task SendCrashesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
