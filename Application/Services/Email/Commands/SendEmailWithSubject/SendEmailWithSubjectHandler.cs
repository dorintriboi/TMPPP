using Core.ExternalServices.EmailServices.Interfaces;
using Core.Services.Email.Commands.SendEmailWithSubject.DTOs;
using MediatR;

namespace Core.Services.Email.Commands.SendEmailWithSubject;

public class SendEmailWithSubjectHandler
    (IEmailServices emailServices) : IRequestHandler<SendEmailWithSubjectCommand>
{
    public async Task Handle(SendEmailWithSubjectCommand request, CancellationToken cancellationToken)
    {
        await emailServices.SendEmailWithSubject(request.ToEmail, request.Subject);
    }
}