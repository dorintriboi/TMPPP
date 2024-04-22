using Core.ExternalServices.EmailClases;
using Core.ExternalServices.EmailServices.Interfaces;
using Core.Services.Email.Queries.GetEmailByIndexViaPop3WithAttachments.DTOs;
using MediatR;

namespace Core.Services.Email.Queries.GetEmailByIndexViaPop3WithAttachments;

public class GetEmailByIndexViaPop3WithAttachmentsHandler(
    IEmailServices emailServices) : IRequestHandler<
    GetEmailByIndexViaPop3WithAttachmentsQuery, EmailPop3WithAttachments>
{
    public async Task<EmailPop3WithAttachments> Handle(GetEmailByIndexViaPop3WithAttachmentsQuery request,
        CancellationToken cancellationToken)
    {
        return await emailServices.ReceiveEmailByIndexViaPop3WithAttachmentsAsync(request.Index);
    }
}