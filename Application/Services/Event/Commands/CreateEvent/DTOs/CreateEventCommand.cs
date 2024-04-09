using Core.Services.Event.Common;
using Core.Validations;
using Domain.Entities.Event.Enum;
using FluentValidation;
using MediatR;

namespace Core.Services.Event.Commands.CreateEvent.DTOs;

public class CreateEventCommand: BaseMediatorDtoValidation<CreateEventCommand>, IRequest<EventDto>
{
    public string InstitutionId { get; set; }
    public string TeamId { get; set; }
    public string SpectacleId { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Location { get; set; }
    public EventStatusType Status { get; set; }
    
    protected override void Validation()
    {
        RuleFor(x => x.InstitutionId)
            .NotEmpty()
            .WithMessage("InstitutionId most be not null");
        
        RuleFor(x => x.TeamId)
            .NotEmpty()
            .WithMessage("TeamId most be not null");
        
        RuleFor(x => x.SpectacleId)
            .NotEmpty()
            .WithMessage("SpectacleId most be not null");
        
        RuleFor(x => x.Date)
            .NotEmpty()
            .WithMessage("Date most be not null");
        
        RuleFor(x => x.Location)
            .NotEmpty()
            .WithMessage("Location most be not null");
        
        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("Status most be not null");
    }
}