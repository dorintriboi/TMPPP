using Domain.Core.Domain.Entities;
using Domain.Entities.Employee;
using Domain.Entities.EmployeeSalary;
using Domain.Entities.Event;
using Domain.Entities.Institution;
using Domain.Entities.Spectacle;
using Domain.Entities.Team;
using Domain.Entities.TeamMember;
using Domain.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole<string>, string>
{
    private string userId;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }       
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
    
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
       // userId = _httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == "Id")?.Value;
        if (userId is null) userId = "InexistingUser";
        foreach (var entity in ChangeTracker.Entries<EntityTrackable>())
        {
            if (entity.State == EntityState.Added)
            {
                entity.Entity.CreatorUserId = userId;
            }
            else
            if (entity.State == EntityState.Modified)
            {
                if (entity.Entity is FullAuditEntity fullAuditEntity)
                {
                    if (fullAuditEntity.IsDeleted == true)
                    {
                        fullAuditEntity.DeleterUserId = userId;
                    }
                    else
                    {
                        fullAuditEntity.LastModifierUserId = userId;
                    }
                }
                else
                if (entity.Entity is AuditEntity auditEntity)
                {
                    auditEntity.LastModifierUserId = userId;
                }
            }
        }
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    
    public DbSet<EmployeeEntity> Employees { get; set; }
    public DbSet<EmployeeSalaryEntity> EmployeeSalaries { get; set; }
    public DbSet<EventEntity> Events { get; set; }
    public DbSet<InstitutionEntity> Institutions { get; set; }
    public DbSet<SpectacleEntity> Spectacles { get; set; }
    public DbSet<TeamEntity> Teams { get; set; }
    public DbSet<TeamMemberEntity> TeamsMembers { get; set; }
    public DbSet<UserEntity> Users { get; set; }
}