﻿using Core.Services.Event.Common;
using Domain.Entities.Event.Enum;
using Domain.Entities.Institution;
using Domain.Entities.Spectacle;
using Domain.Entities.Team;

namespace Application.Core.Managers.EventManager.Models.Out;

public class EventResponseModel
{
    public virtual InstitutionEntity Institution { get; set; }
    public virtual TeamEntity Team { get; set; }
    public virtual SpectacleEntity Spectacle { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Location { get; set; }
    public EventStatusType Status { get; set; }
    
    public static EventResponseModel From(EventDto dto)
    {
        return new EventResponseModel()
        {
            Institution = dto.Institution,
            Team = dto.Team,
            Spectacle = dto.Spectacle,
            Date = dto.Date,
            Location = dto.Location,
            Status = dto.Status
        };
    }
}