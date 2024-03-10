using Domain.Core.Domain.Entities;
using Domain.Entities.Employee;
using Domain.Entities.EmployeeSalary.Enum;

namespace Domain.Entities.EmployeeSalary;

public class EmployeeSalaryEntity : FullAuditEntity
{
    public string EmployeeId { get; set; }
    public virtual EmployeeEntity Employee { get; set; }
    public EmployeeSalaryType Type { get; set; }
    public decimal Value { get; set; }
}