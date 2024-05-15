internal class MTSendEmailRequest
{
    public MTEmailAddress From { get; set; }
    public IEnumerable<MTEmailAddress> To { get; set; }

    public string Subject { get; set; }
    public string Text { get; set; }
    public string Html { get; set; }

    public MTAttachment[] Attachments { get; set; } 
}