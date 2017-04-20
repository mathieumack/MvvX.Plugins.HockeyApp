using Microsoft.HockeyApp;

namespace MvvX.Plugins.HockeyApp.Wpf
{
    public class HockeyAppThread : IHockeyAppThread
    {
        /// <summary>
        /// time of creation as string
        /// </summary>
        public string CreatedAt { get; set; }

        /// <summary>
        /// unique id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// unique token for this thread
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="thread"></param>
        public HockeyAppThread(IFeedbackThread thread)
        {
            CreatedAt = thread.CreatedAt;
            Id = thread.Id;
            Status = thread.Status;
            Token = thread.Token;
        }
    }
}
