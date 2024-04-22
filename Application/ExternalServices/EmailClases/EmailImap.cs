using MailKit;

namespace Core.ExternalServices.EmailClases;

public class EmailImap
{
    public UniqueId MessageId { get; set; }
    public string? From { get; set; }
    public string Subject { get; set; }
    public DateTimeOffset DateSent { get; set; }

    public static EmailImap Create(UniqueId messageId, string? from, string subject, DateTimeOffset date)
    {
        return new EmailImap()
        {
            MessageId = messageId,
            From = from,
            Subject = subject,
            DateSent = date
        };
    }
}