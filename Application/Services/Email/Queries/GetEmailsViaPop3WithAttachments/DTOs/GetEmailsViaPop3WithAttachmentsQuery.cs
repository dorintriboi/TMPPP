using Core.ExternalServices.EmailClases;
using MediatR;

namespace Core.Services.Email.Queries.GetEmailsViaPop3WithAttachments.DTOs;

public class GetEmailsViaPop3WithAttachmentsQuery: IRequest<IEnumerable<EmailPop3WithAttachments>>;