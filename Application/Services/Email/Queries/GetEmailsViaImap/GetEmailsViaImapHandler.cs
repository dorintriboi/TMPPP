using Core.ExternalServices.EmailClases;
using Core.ExternalServices.EmailServices.Interfaces;
using Core.Services.Email.Queries.GetEmailsViaImap.DTOs;
using MediatR;

namespace Core.Services.Email.Queries.GetEmailsViaImap;

public class GetEmailsViaImapHandler(IEmailServices emailServices) : IRequestHandler<
    GetEmailsViaImapQuery,
    IEnumerable<EmailImap>>
{
    public async Task<IEnumerable<EmailImap>> Handle(GetEmailsViaImapQuery request, CancellationToken cancellationToken)
    {
        return await emailServices.ReceiveEmailViaImap();
    }
}