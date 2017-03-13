using MvvX.Plugins.HockeyApp;

namespace Client.Windows
{
    public class HockeyAppAttachment : IHockeyAppAttachment
    {
        //
        // Summary:
        //     Mime content type
        public string ContentType { get; set; }
        //
        // Summary:
        //     Bytes (usually only used when uploading attachments)
        public byte[] DataBytes { get; set; }
        //
        // Summary:
        //     Name of the file when it was uploaded
        public string FileName { get; set; }
    }
}