﻿using Domain.Core.Domain.Interfaces;
using Domain.Entities.Employee;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.User;

public class UserEntity : IdentityUser<string>, IFullAudit
{
    public override string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool? IsDeleted { get; set; }
    public string? DeleterUserId { get; set; }
    public DateTimeOffset DeletionTime { get; set; }
    public DateTimeOffset CreationTime { get; set; }
    public string? CreatorUserId { get; set; }
    public string? LastModifierUserId { get; set; }
    public DateTimeOffset LastModificationTime { get; set; }
    public string? EmployeeId { get; set; }
    public virtual EmployeeEntity Employee { get; set; }
    public override string? SecurityStamp { get; set; }

    public static UserEntity Create(string firstName, string lastName, string password, string email, string phone)
    {
        return new UserEntity()
        {
            Id = new Guid().ToString(),
            FirstName = firstName,
            LastName = lastName,
            PasswordHash = password,
            Email = email,
            PhoneNumber = phone,
            UserName = email
        };
    }
}