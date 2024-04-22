using Domain.Entities.Employee;

namespace Core.Services.Employee.Common;

public class EmployeeDto
{
    public string Id { get; set; }
    public string DateOfBirth { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? SecurityStamp { get; set; }
    
    public static EmployeeDto From(EmployeeEntity entity)
    {
        if (entity is null) return null;
        
        return new EmployeeDto()
        {
            Id = entity.Id,
            DateOfBirth = entity.DateOfBirth,
            FirstName = entity.User.FirstName,
            LastName = entity.User.LastName,
            Email = entity.User.Email,
            SecurityStamp = entity.User.SecurityStamp
        };
    }
}