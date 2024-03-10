using Domain.Core.Domain.Entities;
using Domain.Entities.Employee;
using Domain.Entities.Team;
using Domain.Entities.TeamMember.Enum;

namespace Domain.Entities.TeamMember;

public class TeamMemberEntity : FullAuditEntity
{
    public string EmployeeId { get; set; }
    public virtual EmployeeEntity Employee { get; set; }
    public string TeamId { get; set; }
    public virtual TeamEntity Team { get; set; }
    public TeamMemberDirectionType Direction { get; set; }
}