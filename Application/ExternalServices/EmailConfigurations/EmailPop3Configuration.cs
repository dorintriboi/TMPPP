namespace Core.ExternalServices.EmailConfigurations;

public class EmailPop3Configuration
{
    public const string Pop3 = "Pop3";
    public string UserName { get; set; }
    public string Passward { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public SecurityOptions Secure { get; set; }

    public enum SecurityOptions
    {
        Auto,
        None,
        StartTls,
        SslOnConnect
    }
}