using Core.Services.Institution.Common;
using Core.Validations;
using Domain.Entities.Event.Enum;
using Domain.Entities.Institution.Enum;
using FluentValidation;
using MediatR;

namespace Core.Services.Institution.Commands.CreateInstitution.DTOs;

public class CreateInstitutionCommand: BaseMediatorDtoValidation<CreateInstitutionCommand>, IRequest<InstitutionDto>
{
    public string Name { get; set; }
    public InstitutionType Type { get; set; }
    public string District { get; set; }
    public string Locality { get; set; }
    public string? Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string? Director { get; set; }
    protected override void Validation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name most be not null");
        
        RuleFor(x => x.Type)
            .NotEmpty()
            .WithMessage("Name most be not null");
        
        RuleFor(x => x.District)
            .NotEmpty()
            .WithMessage("Name most be not null");
        
        RuleFor(x => x.Locality)
            .NotEmpty()
            .WithMessage("Name most be not null");
        
        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Name most be not null");
        
        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Name most be not null");
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Name most be not null");
    }
}