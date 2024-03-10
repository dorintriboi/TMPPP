using Domain.Core.Domain.Interfaces;

namespace Domain.Core.Domain.Entities;

public abstract class AuditEntity : EntityTrackable, IAudit
{
    public string? LastModifierUserId {  get;  set; }
    public DateTimeOffset LastModificationTime { get; set; }
}