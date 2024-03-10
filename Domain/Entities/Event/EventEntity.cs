using System.ComponentModel.DataAnnotations;
using Domain.Core.Domain.Entities;
using Domain.Entities.Event.Enum;
using Domain.Entities.Institution;
using Domain.Entities.Spectacle;
using Domain.Entities.Team;

namespace Domain.Entities.Event;

public class EventEntity : FullAuditEntity
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
}