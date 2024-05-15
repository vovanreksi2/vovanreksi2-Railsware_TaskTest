/// <summary>
/// Represents a request to send an email, including text and HTML content, with optional attachments.
/// </summary>
public class SendEmailRequest
{
    /// <summary>
    /// Gets or sets the sender's email address and name.
    /// </summary>
    /// <remarks>
    /// This property is required.
    /// </remarks>
    /// <seealso cref="EmailAddress"/>
    public EmailAddress Sender { get; set; }

    /// <summary>
    /// Gets or sets the recipients' email addresses and names.
    /// </summary>
    /// <remarks>
    /// This property is required.
    /// </remarks>
    /// <seealso cref="EmailAddress"/>
    public IEnumerable<EmailAddress> Recipients { get; set; }

    /// <summary>
    /// The global or 'message level' subject of your email.
    /// This may be overridden by subject lines set in personalizations..
    /// <remarks>
    /// This property is required.
    /// </remarks>
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Text version of the body of the email.
    /// Can be used along with html to create a fallback for non-html clients.
    /// <remarks>
    /// Required in the absence of html.
    /// </remarks>
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// HTML version of the body of the email.
    /// Can be used along with text to create a fallback for non-html clients.
    /// <remarks>
    /// Required in the absence of text.
    /// </remarks>
    /// </summary>
    public string Html { get; set; }

    /// <summary>
    /// An array of objects where you can specify any attachments you want to include
    /// </summary>
    /// <seealso cref="Attachment"/>
    public IEnumerable<Attachment> Attachments { get; set; }
}