using Core.ExternalServices.EmailClases;
using Core.ExternalServices.EmailServices.Interfaces;
using Core.Services.Email.Queries.GetEmailByIdViaImapWithAttachments.DTOs;
using MediatR;

namespace Core.Services.Email.Queries.GetEmailByIdViaImapWithAttachments;

public class GetEmailByIdViaImapWithAttachmentsHandler
    (IEmailServices emailServices) : IRequestHandler<
        GetEmailByIdViaImapWithAttachmentsQuery, EmailImapWithAttachments>
{
    public async Task<EmailImapWithAttachments> Handle(GetEmailByIdViaImapWithAttachmentsQuery request,
        CancellationToken cancellationToken)
    {
        return await emailServices.ReceiveEmailByIdViaImapWithAttachmentsAsync(request.Id);
    }
}