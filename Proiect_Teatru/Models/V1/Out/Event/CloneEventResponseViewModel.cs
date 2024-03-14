using Core.Services.Event.Common;
using Domain.Entities.Event.Enum;
using Domain.Entities.Institution;
using Domain.Entities.Spectacle;
using Domain.Entities.Team;
using Proiect_Teatru.Models.Interfaces.Out;

namespace Proiect_Teatru.Models.V1.Out.Event;

public class CloneEventResponseViewModel: IResponse<CloneEventResponseViewModel,EventDto>
{
    public string Id { get; set; }
    public virtual InstitutionEntity Institution { get; set; }
    public virtual TeamEntity Team { get; set; }
    public virtual SpectacleEntity Spectacle { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Location { get; set; }
    public EventStatusType Status { get; set; }
    
    public static IResponse<CloneEventResponseViewModel, EventDto> Convert(EventDto entity)
    {
        if (entity is null) return null;
        
        return new CloneEventResponseViewModel()
        {
            Id = entity.Id,
            Institution = entity.Institution,
            Team = entity.Team,
            Spectacle = entity.Spectacle,
            Date = entity.Date,
            Location = entity.Location,
            Status = entity.Status
        };
    }
}