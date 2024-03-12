using Core.Validations;
using FluentValidation;
using MediatR;

namespace Core.Services.Account.Commands.UserRegister.DTOs;

public class RegisterUserCommand : BaseMediatorDtoValidation<RegisterUserCommand>, IRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }

    protected override void Validation()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("FirstName most be not null");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("LastName most be not null");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email most be not null");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password most be not null");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("PhoneNumber most be not null");
    }
}