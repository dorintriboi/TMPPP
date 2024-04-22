using Core.ExternalServices.EmailClases;
using Core.ExternalServices.EmailServices.Interfaces;
using MailKit;
using Microsoft.AspNetCore.Http;

namespace Core.ExternalServices.EmailServices.Strategy;

public class MailStrategy : IEmailStrategy
{
    public Task SendEmail()
    {
        throw new NotImplementedException();
    }

    public Task SendEmailWithSubject(string toEmail, string subject)
    {
        throw new NotImplementedException();
    }

    public Task SendEmailWithAttachment(IFormFile attachment, string toEmail, string subject, string replyTo)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EmailPop3>> ReceiveEmailViaPop3Async()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EmailPop3WithAttachments>> ReceiveEmailViaPop3AndAttachmentsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EmailImap>> ReceiveEmailViaImapAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EmailImapWithAttachments>>  ReceiveEmailViaImapWithAttachmentsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EmailPop3WithAttachments> ReceiveEmailByIndexViaPop3WithAttachmentsAsync(int index)
    {
        throw new NotImplementedException();
    }

    public Task<EmailImapWithAttachments> ReceiveEmailByIdViaImapWithAttachmentsAsync(UniqueId id)
    {
        throw new NotImplementedException();
    }

    public Task ReceiveEmailViaImap()
    {
        throw new NotImplementedException();
    }
}