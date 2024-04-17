using Domain.Core.Domain.Entities;
using Domain.Entities.CompanyEvent;
using Domain.Entities.EmployeeCompanyEventType;

namespace Domain.Entities.CompanyEventType;

public class CompanyEventTypeEntity: FullAuditEntity
{
    public string Name { get; set; }
    public virtual ICollection<EmployeeCompanyEventTypeEntity> Employees { get; set; }
    public virtual ICollection<CompanyEventEntity> Events { get; set; }
}