using Domain.Core.Domain.Entities;
using Domain.Entities.CompanyEventType;
using Domain.Entities.Employee;

namespace Domain.Entities.EmployeeCompanyEventType;

public class EmployeeCompanyEventTypeEntity: FullAuditEntity
{
    public string EmployeeId { get; set; }
    public virtual EmployeeEntity Employee { get; set; }
    public string EventTypeId { get; set; }
    public virtual CompanyEventTypeEntity EventType { get; set; }
}