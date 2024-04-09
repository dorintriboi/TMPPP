﻿using Core.Services.Event.Common;
using Core.Validations;
using FluentValidation;
using MediatR;

namespace Core.Services.Event.Commands.CloneEvent.DTOs;

public class CloneEventCommand: BaseMediatorDtoValidation<CloneEventCommand>, IRequest<EventDto>
{
    public string EventId { get; set; }
    public string InstitutionId { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    protected override void Validation()
    {
        RuleFor(x => x.EventId)
            .NotEmpty()
            .WithMessage("EventId most be not null");
        
        RuleFor(x => x.InstitutionId)
            .NotEmpty()
            .WithMessage("InstitutionId most be not null");
        
        RuleFor(x => x.Location)
            .NotEmpty()
            .WithMessage("Location most be not null");
        
        RuleFor(x => x.Date)
            .NotEmpty()
            .WithMessage("Date most be not null");
    }
}