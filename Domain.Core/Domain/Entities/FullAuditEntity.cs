using Domain.Core.Domain.Interfaces;

namespace Domain.Core.Domain.Entities;

public abstract class FullAuditEntity : AuditEntity, IFullAudit
{
    public bool? IsDeleted { get; set; }
    public string? DeleterUserId { get; set; }
    public DateTimeOffset DeletionTime { get; set; }
}