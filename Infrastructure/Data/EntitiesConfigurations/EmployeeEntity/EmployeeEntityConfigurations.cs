using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfigurations.EmployeeEntity;

public class EmployeeEntityConfigurations : IEntityTypeConfiguration<Domain.Entities.Employee.EmployeeEntity>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Employee.EmployeeEntity> builder)
    {
        builder.HasOne(a => a.User)
            .WithOne(x => x.Employee)
            .HasForeignKey<Domain.Entities.Employee.EmployeeEntity>(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(a => a.EmployeeSalaries)
            .WithOne(x => x.Employee)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(a => a.Teams)
            .WithOne(x => x.Employee)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}