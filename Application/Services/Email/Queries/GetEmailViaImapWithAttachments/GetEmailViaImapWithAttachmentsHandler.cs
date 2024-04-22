using Core.ExternalServices.EmailClases;
using Core.ExternalServices.EmailServices.Interfaces;
using Core.Services.Email.Queries.GetEmailViaImapWithAttachments.DTOs;
using MediatR;

namespace Core.Services.Email.Queries.GetEmailViaImapWithAttachments;

public class GetEmailViaImapWithAttachmentsHandler(IEmailServices emailServices) :
    IRequestHandler<
        GetEmailsViaImapWithAttachmentsQuery,
        IEnumerable<EmailImapWithAttachments>>
{
    public async Task<IEnumerable<EmailImapWithAttachments>> Handle(GetEmailsViaImapWithAttachmentsQuery request,
        CancellationToken cancellationToken)
    {
        return await emailServices.ReceiveEmailViaImapWithAttachmentsAsync();
    }
}