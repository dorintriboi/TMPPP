using Core.Validations;
using FluentValidation;
using MediatR;

namespace Core.Services.Email.Commands.SendEmailWithSubject.DTOs;

public class SendEmailWithSubjectCommand : BaseMediatorDtoValidation<SendEmailWithSubjectCommand>, IRequest
{
    public string ToEmail { get; set; } 
    public string Subject { get; set; } 

    protected override void Validation()
    {
        RuleFor(x => x.ToEmail)
            .NotEmpty()
            .WithMessage("ToEmail most be not null");

        RuleFor(x => x.Subject)
            .NotEmpty()
            .WithMessage("Subject most be not null");
    }
}