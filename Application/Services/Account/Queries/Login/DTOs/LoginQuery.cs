using Core.Validations;
using FluentValidation;
using MediatR;

namespace Core.Services.Account.Queries.Login.DTOs;

public class LoginQuery: BaseMediatorDtoValidation<LoginQuery>, IRequest<string>
{
    public string Email { get; set; }
    public string Password { get; set; }
    protected override void Validation()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Name most be not null");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Name most be not null");
    }
}