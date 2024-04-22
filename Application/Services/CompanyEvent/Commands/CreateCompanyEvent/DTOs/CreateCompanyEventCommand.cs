using Core.Services.CompanyEvent.Common;
using Core.Validations;
using FluentValidation;
using MediatR;

namespace Core.Services.CompanyEvent.Commands.CreateCompanyEvent.DTOs;

public class CreateCompanyEventCommand: BaseMediatorDtoValidation<CreateCompanyEventCommand>, IRequest<CompanyEventDto>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string TypeId { get; set; }
    
    protected override void Validation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name most be not null");
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description most be not null");
        
        RuleFor(x => x.TypeId)
            .NotEmpty()
            .WithMessage("TypeId most be not null");
    }
}