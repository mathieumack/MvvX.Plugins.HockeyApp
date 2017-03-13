namespace MvvX.Plugins.HockeyApp
{
    public interface IHockeyAppAttachment
    {
        //
        // Summary:
        //     Mime content type
        string ContentType { get; set; }
        //
        // Summary:
        //     Bytes (usually only used when uploading attachments)
        byte[] DataBytes { get; set; }
        //
        // Summary:
        //     Name of the file when it was uploaded
        string FileName { get; set; }
    }
}