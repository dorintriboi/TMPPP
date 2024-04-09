using Core.Services.Spectacle.Common;
using Core.Validations;
using Domain.Entities.Spectacle.Enum;
using FluentValidation;
using MediatR;

namespace Core.Services.Spectacle.Commands.DTOs;

public class CreateSpectacleCommand: BaseMediatorDtoValidation<CreateSpectacleCommand>, IRequest<SpectacleDto>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public SpectacleType Type { get; set; }
    protected override void Validation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name most be not null");
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description most be not null");
        
        RuleFor(x => x.Type)
            .NotEmpty()
            .WithMessage("Type most be not null");
    }
}