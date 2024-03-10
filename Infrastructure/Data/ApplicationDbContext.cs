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
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole<string>, string>
{
    private string _userId;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        modelBuilder.Entity<IdentityRole<string>>().HasData(new IdentityRole<string>
        {
            Id = new Guid("2b391be4-2886-4ff9-a065-f6c45ba46b60").ToString(), Name = "Admin", NormalizedName = "ADMIN"
        });
        modelBuilder.Entity<IdentityRole<string>>().HasData(new IdentityRole<string>
        {
            Id = new Guid("eeccb9fa-17c8-44c3-9ebf-b6d32ec6354f").ToString(), Name = "User", NormalizedName = "USER"
        });
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default)
    {
        _userId = _httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == "Id")?.Value ??
                  string.Empty;
        if (_userId.IsNullOrEmpty()) _userId = "In-existingUser";
        foreach (var entity in ChangeTracker.Entries<EntityTrackable>())
        {
            if (entity.State == EntityState.Added)
            {
                entity.Entity.CreatorUserId = _userId;
            }
            else if (entity.State == EntityState.Modified)
            {
                if (entity.Entity is FullAuditEntity fullAuditEntity)
                {
                    if (fullAuditEntity.IsDeleted == true)
                    {
                        fullAuditEntity.DeleterUserId = _userId;
                    }
                    else
                    {
                        fullAuditEntity.LastModifierUserId = _userId;
                    }
                }
                else if (entity.Entity is AuditEntity auditEntity)
                {
                    auditEntity.LastModifierUserId = _userId;
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