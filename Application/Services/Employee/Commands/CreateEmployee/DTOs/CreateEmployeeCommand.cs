using Core.Services.Employee.Common;
using Core.Validations;
using FluentValidation;
using MediatR;

namespace Core.Services.Employee.Commands.CreateEmployee.DTOs;

public class CreateEmployeeCommand: BaseMediatorDtoValidation<CreateEmployeeCommand>, IRequest<EmployeeDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string DateOfBirth { get; set; }
    public string? SecurityStamp { get; set; }
    public string PhoneNumber { get; set; }
    
    protected override void Validation()
    {
        RuleFor(x => x.DateOfBirth)
            .NotEmpty()
            .WithMessage("DateOfBirth most be not null");
        
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("FirstName most be not null");
        
        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("LastName most be not null");
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email most be not null");
        
        RuleFor(x => x.SecurityStamp)
            .NotEmpty()
            .WithMessage("Location most be not null");
        
        RuleFor(x => x.SecurityStamp)
            .NotEmpty()
            .WithMessage("Status most be not null");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password most be not null");
        
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("PhoneNumber most be not null");
    }
}