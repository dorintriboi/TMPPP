namespace Core.ExternalServices.EmailClases;

[Serializable]
public class EmailPop3WithAttachments
{
    public int MessageNumber { get; set; }
    public string? From { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTimeOffset DateSent { get; set; }
    public IEnumerable<Attachment>? Attachments { get; set; } = new List<Attachment>();
}

[Serializable]
public class Attachment(string? fileName, string? contentType, byte[]? content = null)
{
    public string? FileName { get; set; } = fileName;
    public string? ContentType { get; set; } = contentType;
    public byte[]? Content { get; set; } = content;
}