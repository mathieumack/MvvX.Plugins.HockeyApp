using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvvX.Plugins.HockeyApp.MoqUnitTest
{
    public class MoqHockeyAppClient : IHockeyClient
    {
        private bool activateTelemetry;
        private bool activateMetrics;
        private bool activateCrashReports;

        private readonly List<string> pageViews;
        private readonly List<MoqHockeyAppEvent> events;
        private readonly List<MoqHockeyAppTrace> traces;
        private readonly List<MoqHockeyAppException> exceptions;
        private readonly List<MoqHockeyAppMetrics> metrics;
        private readonly List<IHockeyAppThread> threads;

        public MoqHockeyAppClient()
        {
            pageViews = new List<string>();
            events = new List<MoqHockeyAppEvent>();
            traces = new List<MoqHockeyAppTrace>();
            exceptions = new List<MoqHockeyAppException>();
            metrics = new List<MoqHockeyAppMetrics>();
            threads = new List<IHockeyAppThread>();
        }

        public void Configure(string identifier, string version, bool activateTelemetry, bool activateMetrics, bool activateCrashReports)
        {
            this.activateTelemetry = activateTelemetry;
            this.activateMetrics = activateMetrics;
            this.activateCrashReports = activateCrashReports;
        }
        
        public async Task SendCrashesAsync()
        {
            exceptions.Clear();
        }

        public void Flush()
        {
            pageViews.Clear();
            events.Clear();
            traces.Clear();
            exceptions.Clear();
            metrics.Clear();
            threads.Clear();
        }

        public void TrackEvent(string eventName)
        {
            if (activateMetrics)
                events.Add(new MoqHockeyAppEvent()
                {
                    EventName = eventName
                });
        }

        public void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            if (activateMetrics)
            {
                events.Add(new MoqHockeyAppEvent()
                {
                    EventName = eventName,
                    Properties = properties,
                    Metrics = metrics
                });
            }
        }

        public void TrackException(Exception ex, IDictionary<string, string> properties = null)
        {
            if (activateCrashReports)
                exceptions.Add(new MoqHockeyAppException()
                {
                    Exception = ex,
                    Properties = properties
                });
        }

        public void TrackMetric(string name, double value, IDictionary<string, string> properties = null)
        {
            if (activateMetrics)
                metrics.Add(new MoqHockeyAppMetrics()
                {
                    Name = name,
                    Value = value,
                    Properties = properties,
                });
        }

        public void TrackPageView(string name)
        {
            pageViews.Add(name);
        }

        public void TrackTrace(string message)
        {
            traces.Add(new MoqHockeyAppTrace()
            {
                Message = message
            });
        }

        public void TrackTrace(string message, IDictionary<string, string> properties)
        {
            traces.Add(new MoqHockeyAppTrace()
            {
                Message = message
            });
        }

        public void TrackTrace(string message, SeverityLevel severityLevel)
        {
            traces.Add(new MoqHockeyAppTrace()
            {
                Message = message,
                SeverityLevel = severityLevel
            });
        }

        public void TrackTrace(string message, SeverityLevel severityLevel, IDictionary<string, string> properties)
        {
            traces.Add(new MoqHockeyAppTrace()
            {
                Message = message,
                SeverityLevel = severityLevel,
                Properties = properties
            });
        }

        public async Task<IHockeyAppThread> TrySendFeedbackAsync(string message, string email, string subject, string name, IList<IHockeyAppAttachment> files)
        {
            try
            {
                return await SendFeedbackAsync(message, email, subject, name, files);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IHockeyAppThread> SendFeedbackAsync(string message, string email, string subject, string name, IList<IHockeyAppAttachment> files)
        {
            threads.Add(new MoqHockeyAppThread(threads.Count)
            {
                Message = message,
                Email = email,
                Subject = subject,
                Name = name,
                Files = files
            });

            return threads.Last();
        }
    }
}
