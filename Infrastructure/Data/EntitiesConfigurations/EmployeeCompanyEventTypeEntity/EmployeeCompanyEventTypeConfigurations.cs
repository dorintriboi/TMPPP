using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfigurations.EmployeeCompanyEventTypeEntity;

public class EmployeeCompanyEventTypeConfigurations: IEntityTypeConfiguration<Domain.Entities.EmployeeCompanyEventType.EmployeeCompanyEventTypeEntity>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.EmployeeCompanyEventType.EmployeeCompanyEventTypeEntity> builder)
    {
        builder.HasOne(a => a.EventType)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.EventTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(a => a.Employee)
            .WithMany(x => x.EventTypes)
            .HasForeignKey(x => x.EventTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}