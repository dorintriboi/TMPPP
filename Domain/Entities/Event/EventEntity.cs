using Domain.Core.Domain.Entities;
using Domain.Core.Domain.Interfaces;
using Domain.Entities.Event.Enum;
using Domain.Entities.Institution;
using Domain.Entities.Spectacle;
using Domain.Entities.Team;

namespace Domain.Entities.Event;

public class EventEntity : FullAuditEntity, IClone<EventEntity>
{
    public string InstitutionId { get; set; }
    public virtual InstitutionEntity Institution { get; set; }
    public string TeamId { get; set; }
    public virtual TeamEntity Team { get; set; }
    public string SpectacleId { get; set; }
    public virtual SpectacleEntity Spectacle { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Location { get; set; }
    public EventStatusType Status { get; set; }

    public static EventEntity Create(InstitutionEntity institution, TeamEntity team, SpectacleEntity spectacle, DateTime date,
        string location, EventStatusType status)
    {
        return new EventEntity()
        {
            InstitutionId = institution.Id,
            Institution = institution,
            TeamId = team.Id,
            Team = team,
            SpectacleId = spectacle.Id,
            Spectacle = spectacle,
            Date = date,
            Location = location,
            Status = status
        };
    }

    public EventEntity Clone()
    {
        return new EventEntity()
        {
            InstitutionId = InstitutionId,
            Institution = Institution,
            TeamId = TeamId,
            Team = Team,
            SpectacleId = SpectacleId,
            Spectacle = Spectacle,
            Date = Date,
            Location = Location,
            Status = Status
        };
    }
}