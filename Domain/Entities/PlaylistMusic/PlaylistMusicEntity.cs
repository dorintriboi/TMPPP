using Domain.Core.Domain.Entities;

namespace Domain.Entities.PlaylistMusic;

public class PlaylistMusicEntity: FullAuditEntity
{
    public string ReferenceId { get; set; }
    public ReferenceType Type { get; set; }
}