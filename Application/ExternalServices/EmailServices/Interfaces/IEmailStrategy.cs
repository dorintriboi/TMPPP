using Core.ExternalServices.EmailClases;
using MailKit;
using Microsoft.AspNetCore.Http;

namespace Core.ExternalServices.EmailServices.Interfaces;

public interface IEmailStrategy
{
    Task<IEnumerable<EmailPop3>> ReceiveEmailViaPop3Async();
    Task<IEnumerable<EmailPop3WithAttachments>> ReceiveEmailViaPop3AndAttachmentsAsync();
    
    Task<IEnumerable<EmailImap>> ReceiveEmailViaImapAsync();
    Task<IEnumerable<EmailImapWithAttachments>>  ReceiveEmailViaImapWithAttachmentsAsync();
    
    Task<EmailPop3WithAttachments> ReceiveEmailByIndexViaPop3WithAttachmentsAsync(int index);
    Task<EmailImapWithAttachments> ReceiveEmailByIdViaImapWithAttachmentsAsync(UniqueId id);
    
    Task SendEmailWithSubject(string toEmail, string subject);
    Task SendEmailWithAttachment(IFormFile attachment, string toEmail, string subject, string replyTo);
}