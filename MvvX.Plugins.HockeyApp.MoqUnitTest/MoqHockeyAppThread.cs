using System;
using System.Collections.Generic;

namespace MvvX.Plugins.HockeyApp.MoqUnitTest
{
    public class MoqHockeyAppThread : IHockeyAppThread
    {
        public string Message { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Name { get; set; }
        public IList<IHockeyAppAttachment> Files { get; set; }

        public string CreatedAt { get; private set; }

        public int Id { get; private set; }

        public int Status { get; private set; }

        public string Token { get; private set; }

        public MoqHockeyAppThread(int id)
        {
            CreatedAt = DateTime.UtcNow.ToLongTimeString();
            Id = id;
            Status = 0;
            Token = Guid.NewGuid().ToString();
        }
    }
}
