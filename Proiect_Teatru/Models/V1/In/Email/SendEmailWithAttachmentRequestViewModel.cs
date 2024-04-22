using Core.Services.Email.Commands.SendEmailWithAttachment.DTOs;
using MediatR;

namespace Proiect_Teatru.Models.V1.In.Email;

public class SendEmailWithAttachmentRequestViewModel
    : IRequest<SendEmailWithAttachmentCommand>
{
    public IFormFile Attachment { get; set; } 
    public string ToEmail { get; set; } 
    public string Subject { get; set; } 
    public string ReplyTo { get; set; } 

    public SendEmailWithAttachmentCommand Convert()
    {
        return new SendEmailWithAttachmentCommand
        {
            Attachment = Attachment,
            ToEmail = ToEmail,
            Subject = Subject,
            ReplyTo = ReplyTo
        };
    }
}