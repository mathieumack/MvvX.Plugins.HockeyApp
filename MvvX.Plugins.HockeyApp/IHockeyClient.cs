using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvvX.Plugins.HockeyApp
{
    public interface IHockeyClient
    {
        /// <summary>
        /// Send crashes to the server
        /// </summary>
        /// <returns></returns>
        Task SendCrashesAsync();

        /// <summary>
        /// Start configuration of the api with your app identifier
        /// </summary>
        /// <param name="identifier"></param>
        void Configure(string identifier, string version, bool activateTelemetry, bool activateMetrics, bool activateCrashReports);
        void Flush();
        //void TrackDependency(DependencyTelemetry telemetry);
        //void TrackDependency(string dependencyName, string commandName, DateTimeOffset startTime, TimeSpan duration, bool success);
        void TrackEvent(string eventName);
        //void TrackEvent(EventTelemetry telemetry);
        void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null);
        void TrackException(Exception ex, IDictionary<string, string> properties = null);
        //void TrackMetric(MetricTelemetry telemetry);
        void TrackMetric(string name, double value, IDictionary<string, string> properties = null);
        void TrackPageView(string name);
        //void TrackPageView(PageViewTelemetry telemetry);
        void TrackTrace(string message);
        //void TrackTrace(TraceTelemetry telemetry);
        void TrackTrace(string message, SeverityLevel severityLevel);
        void TrackTrace(string message, IDictionary<string, string> properties);
        void TrackTrace(string message, SeverityLevel severityLevel, IDictionary<string, string> properties);
    }
}

