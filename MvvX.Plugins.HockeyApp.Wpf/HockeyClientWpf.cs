﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.HockeyApp;
using Microsoft.HockeyApp.Model;

namespace MvvX.Plugins.HockeyApp.Wpf
{
    public class HockeyClientWpf : IHockeyClient
    {
        private bool activateTelemetry;
        private bool activateMetrics;
        private bool activateCrashReports;

        public void Configure(string identifier, string version, bool activateTelemetry, bool activateMetrics, bool activateCrashReports)
        {
            var hockeyClient = (HockeyClient)HockeyClient.Current;

            if (activateTelemetry)
            {
                hockeyClient.Configure(identifier)
                        .RegisterCustomDispatcherUnhandledExceptionLogic(OnUnhandledDispatcherException)
                        .UnregisterDefaultUnobservedTaskExceptionHandler();
            }

            this.activateTelemetry = activateTelemetry;
            this.activateMetrics = activateMetrics;
            this.activateCrashReports = activateCrashReports;
        }

        private void OnUnhandledDispatcherException(System.Windows.Threading.DispatcherUnhandledExceptionEventArgs obj)
        {
            //throw new NotImplementedException();
        }

        public async Task SendCrashesAsync()
        {
            await HockeyClient.Current.SendCrashesAsync();
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
            var hockeyClient = (HockeyClient)HockeyClient.Current;
            hockeyClient.TrackEvent(eventName, properties, metrics);
        }

        public void TrackException(Exception ex, IDictionary<string, string> properties = null)
        {
            if (activateCrashReports)
                HockeyClient.Current.TrackException(ex, properties);
        }

        public void TrackMetric(string name, double value, IDictionary<string, string> properties = null)
        {
            if (activateMetrics)
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
            var attachments = new List<IFeedbackAttachment>();
            foreach (var file in files)
            {
                attachments.Add(new FeedbackAttachment(file.FileName, file.DataBytes, file.ContentType));
            }
            var thread = HockeyClient.Current.CreateFeedbackThread();
            var feedbackMessage = await thread.PostFeedbackMessageAsync(message, email, subject, name, attachments);
            thread = await HockeyClient.Current.OpenFeedbackThreadAsync(thread.Token);
            return new HockeyAppThread(thread);
        }
    }
}
