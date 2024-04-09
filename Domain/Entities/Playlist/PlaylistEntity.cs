using Domain.Core.Domain.Entities;
using Domain.Entities.PlaylistMusic;
using Domain.Entities.Spectacle;

namespace Domain.Entities.Playlist;

public class PlaylistEntity: FullAuditEntity
{
    public string Name { get; set; }
    public virtual ICollection<PlaylistMusicEntity> Music { get; set; }
    public virtual ICollection<SpectacleEntity> Spectales { get; set; }
}