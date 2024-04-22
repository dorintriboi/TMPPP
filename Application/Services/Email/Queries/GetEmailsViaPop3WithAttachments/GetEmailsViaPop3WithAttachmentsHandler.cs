using Core.ExternalServices.EmailClases;
using Core.ExternalServices.EmailServices.Interfaces;
using Core.Services.Email.Queries.GetEmailsViaPop3WithAttachments.DTOs;
using MediatR;

namespace Core.Services.Email.Queries.GetEmailsViaPop3WithAttachments;

public class GetEmailsViaPop3WithAttachmentsHandler
    (IEmailServices emailServices) : IRequestHandler<
        GetEmailsViaPop3WithAttachmentsQuery,
        IEnumerable<EmailPop3WithAttachments>>
{
    public async Task<IEnumerable<EmailPop3WithAttachments>> Handle(GetEmailsViaPop3WithAttachmentsQuery request,
        CancellationToken cancellationToken)
    {
        return await emailServices.ReceiveEmailViaPop3AndAttachmentsAsync();
    }
}