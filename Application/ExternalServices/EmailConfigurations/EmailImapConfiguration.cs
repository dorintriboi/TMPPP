namespace Core.ExternalServices.EmailConfigurations;

public class EmailImapConfiguration
{
    public const string Imap = "Imap";
    public string UserName { get; set; }
    public string Passward { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
}