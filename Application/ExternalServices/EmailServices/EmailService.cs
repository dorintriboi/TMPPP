using Core.ExternalServices.EmailClases;
using Core.ExternalServices.EmailServices.Interfaces;
using MailKit;
using Microsoft.AspNetCore.Http;

namespace Core.ExternalServices.EmailServices;

public class EmailService(IEmailStrategy emailStrategy) : IEmailServices
{
    public async Task<IEnumerable<EmailPop3>> ReceiveEmailViaPop3Async()
    {
        return await emailStrategy.ReceiveEmailViaPop3Async();
    }

    public async Task<IEnumerable<EmailPop3WithAttachments>> ReceiveEmailViaPop3AndAttachmentsAsync()
    {
        return await emailStrategy.ReceiveEmailViaPop3AndAttachmentsAsync();
    }

    public async Task<IEnumerable<EmailImap>> ReceiveEmailViaImap()
    {
        return await emailStrategy.ReceiveEmailViaImapAsync();
    }

    public async Task<IEnumerable<EmailImapWithAttachments>> ReceiveEmailViaImapWithAttachmentsAsync()
    {
        return await emailStrategy.ReceiveEmailViaImapWithAttachmentsAsync();
    }

    public async Task<EmailPop3WithAttachments> ReceiveEmailByIndexViaPop3WithAttachmentsAsync(int index)
    {
        return await emailStrategy.ReceiveEmailByIndexViaPop3WithAttachmentsAsync(index);
    }

    public async Task<EmailImapWithAttachments> ReceiveEmailByIdViaImapWithAttachmentsAsync(UniqueId id)
    {
        return await emailStrategy.ReceiveEmailByIdViaImapWithAttachmentsAsync(id);
    }

    public async Task SendEmailWithSubject(string toEmail, string subject)
    {
        await emailStrategy.SendEmailWithSubject(toEmail, subject);
    }

    public async Task SendEmailWithAttachment(IFormFile attachment, string toEmail, string subject, string replyTo)
    {
        await emailStrategy.SendEmailWithAttachment(attachment, toEmail, subject, replyTo);
    }
}