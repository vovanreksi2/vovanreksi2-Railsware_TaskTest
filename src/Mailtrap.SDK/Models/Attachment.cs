/// <summary>
/// An array of objects where you can specify any attachments you want to include
/// </summary>
public class Attachment
{
    /// <summary>
    /// The Base64 encoded content of the attachment
    /// </summary>
    /// <remarks>
    /// This property is required.
    /// </remarks>
    public string Content { get; set; }
    /// <summary>
    /// The attachment's filename.
    /// </summary>
    /// <remarks>
    /// This property is required.
    /// </remarks>
    public string Filename { get; set; }
    /// <summary>
    /// The MIME type of the content you are attaching (e.g., “text/plain” or “text/html”).
    /// </summary>
    public string Type { get; set; }
    /// <summary>
    /// The attachment's content-disposition, specifying how you would like the attachment to be displayed
    /// For example, “inline” results in the attached file are displayed automatically within the message
    /// while “attachment” results in the attached file require some action to be taken before it is displayed, such as opening or downloading the file
    /// <remarks>Available values: inline, attachment</remarks>
    /// <value></value>
    /// </summary>
    public string Disposition { get; set; }
}