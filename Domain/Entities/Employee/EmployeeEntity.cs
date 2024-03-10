using Domain.Core.Domain.Entities;
using Domain.Entities.EmployeeSalary;
using Domain.Entities.TeamMember;
using Domain.Entities.User;

namespace Domain.Entities.Employee;

public class EmployeeEntity : FullAuditEntity
{
    public string DateOfBirth { get; set; }
    public string UserId { get; set; }
    public virtual UserEntity User { get; set; }
    public virtual ICollection<EmployeeSalaryEntity> EmployeeSalaries { get; set; }
    public virtual ICollection<TeamMemberEntity> Teams { get; set; }
}