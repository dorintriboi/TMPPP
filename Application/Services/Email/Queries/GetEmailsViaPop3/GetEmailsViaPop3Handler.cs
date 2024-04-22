using Core.ExternalServices.EmailClases;
using Core.ExternalServices.EmailServices.Interfaces;
using Core.Services.Email.Queries.GetEmailsViaPop3.DTOs;
using MediatR;

namespace Core.Services.Email.Queries.GetEmailsViaPop3;

public class GetEmailsViaPop3Handler(IEmailServices emailServices) : IRequestHandler<
    GetEmailsViaPop3Query,
    IEnumerable<EmailPop3>>
{
    public async Task<IEnumerable<EmailPop3>> Handle(GetEmailsViaPop3Query request, CancellationToken cancellationToken)
    {
        return await emailServices.ReceiveEmailViaPop3Async();
    }
}