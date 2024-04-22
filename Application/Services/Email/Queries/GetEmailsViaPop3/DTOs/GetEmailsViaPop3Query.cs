using Core.ExternalServices.EmailClases;
using MediatR;

namespace Core.Services.Email.Queries.GetEmailsViaPop3.DTOs;

public class GetEmailsViaPop3Query: IRequest<IEnumerable<EmailPop3>>;