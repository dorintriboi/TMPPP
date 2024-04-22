using Core.ExternalServices.EmailClases;
using MediatR;

namespace Core.Services.Email.Queries.GetEmailsViaImap.DTOs;

public class GetEmailsViaImapQuery: IRequest<IEnumerable<EmailImap>>;