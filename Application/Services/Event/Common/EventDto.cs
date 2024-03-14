using Domain.Entities.Event;
using Domain.Entities.Event.Enum;
using Domain.Entities.Institution;
using Domain.Entities.Spectacle;
using Domain.Entities.Team;

namespace Core.Services.Event.Common;

public class EventDto
{
    public virtual InstitutionEntity Institution { get; set; }
    public virtual TeamEntity Team { get; set; }
    public virtual SpectacleEntity Spectacle { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Location { get; set; }
    public EventStatusType Status { get; set; }
    public static EventDto From(EventEntity entity)
    {
        return new EventDto()
        {
            Institution = entity.Institution,
            Team = entity.Team,
            Spectacle = entity.Spectacle,
            Date = entity.Date,
            Location = entity.Location,
            Status = entity.Status
        };
    }
}