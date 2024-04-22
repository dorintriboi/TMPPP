namespace Core.ExternalServices.EmailClases;

[Serializable]
public class EmailPop3
{
    public int MessageNumber { get; set; }
    public string? From { get; set; }
    public string Subject { get; set; }
    public DateTimeOffset DateSent { get; set; }
}
