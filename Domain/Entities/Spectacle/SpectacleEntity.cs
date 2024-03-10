using Domain.Core.Domain.Entities;
using Domain.Entities.Event;
using Domain.Entities.Spectacle.Enum;

namespace Domain.Entities.Spectacle;

public class SpectacleEntity : FullAuditEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public SpectacleType Type { get; set; }
    public virtual ICollection<EventEntity> Events { get; set; }
}