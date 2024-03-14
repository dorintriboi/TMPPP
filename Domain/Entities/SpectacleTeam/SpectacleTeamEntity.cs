using Domain.Core.Domain.Entities;
using Domain.Entities.Spectacle;
using Domain.Entities.Team;

namespace Domain.Entities.SpectacleTeam;

public class SpectacleTeamEntity : FullAuditEntity
{
    public string TeamId { get; set; }
    public virtual TeamEntity Team { get; set; }
    public string SpectacleId { get; set; }
    public virtual SpectacleEntity Spectacle { get; set; }
}