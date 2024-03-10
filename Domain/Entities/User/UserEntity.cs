using Domain.Core.Domain.Interfaces;
using Domain.Entities.Employee;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.User;

public class UserEntity : IdentityUser<string>, IFullAudit
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool? IsDeleted { get; set; }
    public string DeleterUserId { get; set; }
    public DateTimeOffset DeletionTime { get; set; }
    public DateTimeOffset CreationTime { get; set; }
    public string CreatorUserId { get; set; }
    public string LastModifierUserId { get; set; }
    public DateTimeOffset LastModificationTime { get; set; }
    public string EmployeeId { get; set; }
    public virtual EmployeeEntity Employee { get; set; }
}