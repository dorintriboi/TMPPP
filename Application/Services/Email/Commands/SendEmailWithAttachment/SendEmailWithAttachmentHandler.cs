using Core.ExternalServices.EmailServices.Interfaces;
using Core.Services.Email.Commands.SendEmailWithAttachment.DTOs;
using MediatR;

namespace Core.Services.Email.Commands.SendEmailWithAttachment;

public class SendEmailWithAttachmentHandler
    (IEmailServices emailServices) : IRequestHandler<SendEmailWithAttachmentCommand>
{
    public async Task Handle(SendEmailWithAttachmentCommand request, CancellationToken cancellationToken)
    {
        await emailServices.SendEmailWithAttachment(request.Attachment, request.ToEmail, request.Subject,
            request.ReplyTo);
    }
}