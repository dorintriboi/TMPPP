using Core.ExternalServices.EmailClases;
using Core.ExternalServices.EmailConfigurations;
using Core.ExternalServices.EmailServices.Interfaces;
using Domain.Core.Exceptions;
using MailKit;
using MailKit.Net.Pop3;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using Attachment = Core.ExternalServices.EmailClases.Attachment;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Core.ExternalServices.EmailServices.Strategy;

public class GmailStrategy(IOptions<EmailSmtpConfiguration> emailSmtpConfigurations,
    IOptions<EmailPop3Configuration> emailPop3Configurations,
    IOptions<EmailImapConfiguration> emailImapConfigurations) : IEmailStrategy
{
    public SecureSocketOptions GetSecurity(EmailPop3Configuration.SecurityOptions secure)
    {
        switch (secure)
        {
            case EmailPop3Configuration.SecurityOptions.Auto:
                return SecureSocketOptions.Auto;
            case EmailPop3Configuration.SecurityOptions.None:
                return SecureSocketOptions.None;
            case EmailPop3Configuration.SecurityOptions.StartTls:
                return SecureSocketOptions.StartTls;
            case EmailPop3Configuration.SecurityOptions.SslOnConnect:
                return SecureSocketOptions.SslOnConnect;
            default:
                throw new Exception($"SMTP security options {secure} is not supported");
        }
    }

    public async Task SendEmailWithSubject(string toEmail, string subject)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(emailSmtpConfigurations.Value.From));
        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = subject;

        using var smtp = new SmtpClient();

        try
        {
            await smtp.ConnectAsync(emailSmtpConfigurations.Value.Host, emailSmtpConfigurations.Value.Port,
                GetSecurity(emailSmtpConfigurations.Value.Secure));
            await smtp.AuthenticateAsync(emailSmtpConfigurations.Value.UserName,
                emailSmtpConfigurations.Value.Passward);
            await smtp.SendAsync(email);
        }
        catch (Exception e)
        {
            throw new DomainException(e.Message);
        }
        finally
        {
            await smtp.DisconnectAsync(true);
            smtp.Dispose();
        }
    }

    public async Task SendEmailWithAttachment(IFormFile attachment, string toEmail, string subject, string replyTo)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(emailSmtpConfigurations.Value.From));
        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = subject;
        email.ReplyTo.Add(MailboxAddress.Parse(replyTo));
        email.ReplyTo.Add(MailboxAddress.Parse(toEmail));

        await using var memoryStream = new MemoryStream();

        await attachment.CopyToAsync(memoryStream);

        var attachmentBody = new MimePart()
        {
            Content = new MimeContent(memoryStream),
            ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
            ContentTransferEncoding = ContentEncoding.Base64,
            FileName = attachment.FileName
        };

        email.Body = attachmentBody;

        using var smtp = new SmtpClient();

        try
        {
            await smtp.ConnectAsync(emailSmtpConfigurations.Value.Host, emailSmtpConfigurations.Value.Port,
                GetSecurity(emailSmtpConfigurations.Value.Secure));
            await smtp.AuthenticateAsync(emailSmtpConfigurations.Value.UserName,
                emailSmtpConfigurations.Value.Passward);
            await smtp.SendAsync(email);
        }
        catch (Exception e)
        {
            throw new DomainException(e.Message);
        }
        finally
        {
            await smtp.DisconnectAsync(true);
            smtp.Dispose();
        }
    }

    public async Task<IEnumerable<EmailPop3>> ReceiveEmailViaPop3Async()
    {
        using var pop3Client = new Pop3Client();
        var username = emailPop3Configurations.Value.UserName;
        var password = emailPop3Configurations.Value.Passward;

        try
        {
            await pop3Client.ConnectAsync(emailPop3Configurations.Value.Host, emailPop3Configurations.Value.Port,
                GetSecurity(emailPop3Configurations.Value.Secure)
            );

            await pop3Client.AuthenticateAsync(username, password);

            var list = new List<EmailPop3>();
            for (int i = pop3Client.Count - 1; i >= 0; --i)
            {
                MimeMessage message = await pop3Client.GetMessageAsync(i);
                EmailPop3 email = new EmailPop3()
                {
                    MessageNumber = i,
                    Subject = message.Subject,
                    DateSent = message.Date,
                    From = message.From.Mailboxes.FirstOrDefault()?.Address
                };

                list.Add(email);
            }

            return list;
        }
        catch (Exception e)
        {
            throw new DomainException(e.Message);
        }
        finally
        {
            await pop3Client.DisconnectAsync(true);
            pop3Client.Dispose();
        }
    }

    public async Task<IEnumerable<EmailPop3WithAttachments>> ReceiveEmailViaPop3AndAttachmentsAsync()
    {
        using var pop3Client = new Pop3Client();
        var username = emailPop3Configurations.Value.UserName;
        var password = emailPop3Configurations.Value.Passward;

        try
        {
            await pop3Client.ConnectAsync(emailPop3Configurations.Value.Host, emailPop3Configurations.Value.Port,
                GetSecurity(emailPop3Configurations.Value.Secure)
            );

            await pop3Client.AuthenticateAsync(username, password);

            var list = new List<EmailPop3WithAttachments>();
            for (int i = pop3Client.Count - 1; i >= 0; --i)
            {
                MimeMessage message = await pop3Client.GetMessageAsync(i);
                EmailPop3WithAttachments email = new EmailPop3WithAttachments()
                {
                    MessageNumber = i,
                    Subject = message.Subject,
                    DateSent = message.Date,
                    From = message.From.Mailboxes.FirstOrDefault()?.Address,
                    Body = message.Body.ToString() ?? string.Empty,
                    Attachments = await Task.WhenAll(message.Attachments?.Select(async x =>
                    {
                        using var memory = new MemoryStream();
                        if (x is MimePart)
                            await ((MimePart)x).Content.DecodeToAsync(memory);

                        var bytes = memory.ToArray();
                        return new Attachment(x?.ContentType?.Name, x?.ContentType?.MediaSubtype, bytes);
                    }) ?? Array.Empty<Task<Attachment>>())
                };

                list.Add(email);
                await pop3Client.DeleteMessageAsync(i);
            }

            return list;
        }
        catch (Exception e)
        {
            throw new DomainException(e.Message);
        }
        finally
        {
            await pop3Client.DisconnectAsync(true);
            pop3Client.Dispose();
        }
    }

    public async Task<IEnumerable<EmailImap>> ReceiveEmailViaImapAsync()
    {
        using var client = new ImapClient();
        var username = emailImapConfigurations.Value.UserName;
        var password = emailImapConfigurations.Value.Passward;

        try
        {
            await client.ConnectAsync(emailImapConfigurations.Value.Host, emailImapConfigurations.Value.Port,
                true
            );

            await client.AuthenticateAsync(username, password);

            var inbox = client.Inbox;
            await inbox.OpenAsync(FolderAccess.ReadWrite);
            var emailIds = await inbox.SearchAsync(SearchQuery.NotSeen);

            var emails = new List<EmailImap>();
            foreach (var uid in emailIds)
            {
                Console.WriteLine(uid);
                var message = await inbox.GetMessageAsync(uid);
                emails.Add(
                    EmailImap.Create(uid, message.From?.Mailboxes?.FirstOrDefault()?.Address,
                        message.Subject, message.Date));
            }

            return emails;
        }
        catch (Exception e)
        {
            throw new DomainException(e.Message);
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }

    public async Task<IEnumerable<EmailImapWithAttachments>> ReceiveEmailViaImapWithAttachmentsAsync()
    {
        using var client = new ImapClient();
        var username = emailImapConfigurations.Value.UserName;
        var password = emailImapConfigurations.Value.Passward;

        try
        {
            await client.ConnectAsync(emailImapConfigurations.Value.Host, emailImapConfigurations.Value.Port,
                true
            );

            await client.AuthenticateAsync(username, password);

            var inbox = client.Inbox;
            await inbox.OpenAsync(FolderAccess.ReadWrite);
            var emailIds = await inbox.SearchAsync(SearchQuery.NotSeen);

            var emails = new List<EmailImapWithAttachments>();
            foreach (var uid in emailIds)
            {
                Console.WriteLine(uid);
                var message = await inbox.GetMessageAsync(uid);
                emails.Add(
                    EmailImapWithAttachments.Create(uid.ToString(),
                        message.From?.Mailboxes?.FirstOrDefault()?.Address, message.Body.ToString() ?? string.Empty,
                        message.Subject, message.Date, await Task.WhenAll(message.Attachments?.Select(async x =>
                        {
                            using var memory = new MemoryStream();
                            if (x is MimePart)
                                await ((MimePart)x).Content.DecodeToAsync(memory);

                            var bytes = memory.ToArray();
                            return new EmailImapWithAttachments.Attachment(x?.ContentType?.Name,
                                x?.ContentType?.MediaSubtype, bytes);
                        }) ?? Array.Empty<Task<EmailImapWithAttachments.Attachment>>())));
            }

            return emails;
        }
        catch (Exception e)
        {
            throw new DomainException(e.Message);
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }

    public async Task<EmailPop3WithAttachments> ReceiveEmailByIndexViaPop3WithAttachmentsAsync(int index)
    {
        using var pop3Client = new Pop3Client();
        var username = emailPop3Configurations.Value.UserName;
        var password = emailPop3Configurations.Value.Passward;

        try
        {
            await pop3Client.ConnectAsync(emailPop3Configurations.Value.Host, emailPop3Configurations.Value.Port,
                GetSecurity(emailPop3Configurations.Value.Secure)
            );

            await pop3Client.AuthenticateAsync(username, password);

            MimeMessage message = await pop3Client.GetMessageAsync(index);
            EmailPop3WithAttachments email = new EmailPop3WithAttachments()
            {
                MessageNumber = index,
                Subject = message.Subject,
                DateSent = message.Date,
                From = message.From.Mailboxes.FirstOrDefault()?.Address,
                Body = message.Body.ToString() ?? string.Empty,
                Attachments = await Task.WhenAll(message.Attachments?.Select(async x =>
                {
                    using var memory = new MemoryStream();
                    if (x is MimePart)
                        await ((MimePart)x).Content.DecodeToAsync(memory);

                    var bytes = memory.ToArray();
                    return new Attachment(x?.ContentType?.Name, x?.ContentType?.MediaSubtype, bytes);
                }) ?? Array.Empty<Task<Attachment>>())
            };

            return email;
        }
        catch (Exception e)
        {
            throw new DomainException(e.Message);
        }
        finally
        {
            await pop3Client.DisconnectAsync(true);
            pop3Client.Dispose();
        }
    }

    public async Task<EmailImapWithAttachments> ReceiveEmailByIdViaImapWithAttachmentsAsync(UniqueId id)
    {
        using var client = new ImapClient();
        var username = emailImapConfigurations.Value.UserName;
        var password = emailImapConfigurations.Value.Passward;

        try
        {
            await client.ConnectAsync(emailImapConfigurations.Value.Host, emailImapConfigurations.Value.Port,
                true
            );

            await client.AuthenticateAsync(username, password);

            var inbox = client.Inbox;
            await inbox.OpenAsync(FolderAccess.ReadWrite);

            var message = await inbox.GetMessageAsync(id);

            var email = EmailImapWithAttachments.Create(id.ToString(),
                message.From?.Mailboxes?.FirstOrDefault()?.Address, message.Body.ToString() ?? string.Empty,
                message.Subject, message.Date, await Task.WhenAll(message.Attachments?.Select(async x =>
                {
                    using var memory = new MemoryStream();
                    if (x is MimePart)
                        await ((MimePart)x).Content.DecodeToAsync(memory);

                    var bytes = memory.ToArray();
                    return new EmailImapWithAttachments.Attachment(x?.ContentType?.Name,
                        x?.ContentType?.MediaSubtype, bytes);
                }) ?? Array.Empty<Task<EmailImapWithAttachments.Attachment>>()));

            return email;
        }
        catch (Exception e)
        {
            throw new DomainException(e.Message);
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }
}