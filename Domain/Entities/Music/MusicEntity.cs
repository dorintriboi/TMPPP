using Domain.Core.Domain.Entities;

namespace Domain.Entities.Music;

public class MusicEntity : FullAuditEntity
{
    public string Name { get; set; }
    public string Base64 { get; set; }
}