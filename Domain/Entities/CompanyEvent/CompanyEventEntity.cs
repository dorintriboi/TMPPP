using Domain.Core.Domain.Entities;
using Domain.Entities.CompanyEventType;

namespace Domain.Entities.CompanyEvent;

public class CompanyEventEntity: FullAuditEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string TypeId { get; set; }
    public virtual CompanyEventTypeEntity Type { get; set; }
}