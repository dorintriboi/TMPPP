using Core.Services.Email.Commands.SendEmailWithSubject.DTOs;
using MediatR;

namespace Proiect_Teatru.Models.V1.In.Email;

public class SendEmailWithSubjectRequestViewModel : IRequest<SendEmailWithSubjectCommand>
{
    public string ToEmail { get; set; } 
    public string Subject { get; set; } 

    public SendEmailWithSubjectCommand Convert()
    {
        return new SendEmailWithSubjectCommand
        {
            ToEmail = ToEmail,
            Subject = Subject
        };
    }
}