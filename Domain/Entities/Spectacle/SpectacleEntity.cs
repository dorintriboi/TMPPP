using Domain.Core.Domain.Entities;
using Domain.Entities.Event;
using Domain.Entities.Playlist;
using Domain.Entities.Spectacle.Enum;
using Domain.Entities.SpectacleTeam;

namespace Domain.Entities.Spectacle;

public class SpectacleEntity : FullAuditEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public SpectacleType Type { get; set; }
    public virtual ICollection<EventEntity> Events { get; set; }
    public virtual ICollection<SpectacleTeamEntity> Teams { get; set; }
    public string PlaylistId { get; set; }
    public virtual PlaylistEntity Playlist { get; set; }
    
    public static SpectacleEntity Create(string name, string description, SpectacleType type)
    {
        return new SpectacleEntity()
        {
            Name = name,
            Description = description,
            Type = type
        };
    }
}