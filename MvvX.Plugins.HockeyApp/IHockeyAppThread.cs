namespace MvvX.Plugins.HockeyApp
{
    /// <summary>
    /// interface for a hockeyapp feedback thread
    /// </summary>
    public interface IHockeyAppThread
    {
        /// <summary>
        /// time of creation as string
        /// </summary>
        string CreatedAt { get; }

        /// <summary>
        /// unique id
        /// </summary>
        int Id { get; }

        /// <summary>
        /// status
        /// </summary>
        int Status { get; }

        /// <summary>
        /// unique token for this thread
        /// </summary>
        string Token { get; }
    }
}
