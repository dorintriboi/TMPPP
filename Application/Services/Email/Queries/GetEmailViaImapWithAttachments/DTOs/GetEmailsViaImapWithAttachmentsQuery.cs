using Core.ExternalServices.EmailClases;
using MediatR;

namespace Core.Services.Email.Queries.GetEmailViaImapWithAttachments.DTOs;

public class GetEmailsViaImapWithAttachmentsQuery: IRequest<IEnumerable<EmailImapWithAttachments>>;