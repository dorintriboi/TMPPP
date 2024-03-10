using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfigurations.EmployeeSalaryEntity;

public class EmployeeSalaryEntityConfigurations : IEntityTypeConfiguration<Domain.Entities.EmployeeSalary.EmployeeSalaryEntity>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.EmployeeSalary.EmployeeSalaryEntity> builder)
    {
        builder.HasOne(a => a.Employee)
            .WithMany(x => x.EmployeeSalaries)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}