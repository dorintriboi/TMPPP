namespace Core.ExternalServices.EmailConfigurations;

public class EmailSmtpConfiguration
{
    public const string Email = "Email";
    public string UserName { get; set; }
    public string Passward { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public EmailPop3Configuration.SecurityOptions Secure { get; set; }
}