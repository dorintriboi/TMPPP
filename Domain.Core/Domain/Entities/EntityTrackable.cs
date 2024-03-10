using Domain.Core.Domain.Interfaces;

namespace Domain.Core.Domain.Entities;

public class EntityTrackable : Entity, ITrackable
{
    protected EntityTrackable()
    {
        CreationTime = DateTimeOffset.UtcNow;
    }
    
    public DateTimeOffset CreationTime { get; set; }
    public string CreatorUserId { get; set; }
}