using MailKit;

namespace Core.ExternalServices.EmailClases;

[Serializable]
public class EmailImapWithAttachments
{
    public string? MessageId { get; set; }
    public string? From { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTimeOffset DateSent { get; set; }
    public IEnumerable<Attachment>? Attachments { get; set; } = new List<Attachment>();

    public static EmailImapWithAttachments Create(string? messageId, string? from, string subject, string body,
        DateTimeOffset date, IEnumerable<Attachment> attachments)
    {
        return new EmailImapWithAttachments()
        {
            MessageId = messageId,
            From = from,
            Subject = subject,
            Body = body,
            DateSent = date,
            Attachments = attachments,
        };
    }

    [Serializable]
    public class Attachment(string? fileName, string? contentType, byte[]? content = null)
    {
        public string? FileName { get; set; } = fileName;
        public string? ContentType { get; set; } = contentType;
        public byte[]? Content { get; set; } = content;
    }
}