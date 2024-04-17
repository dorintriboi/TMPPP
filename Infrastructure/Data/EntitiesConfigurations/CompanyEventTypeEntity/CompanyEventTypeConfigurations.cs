using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfigurations.CompanyEventTypeEntity;

public class CompanyEventTypeConfigurations: IEntityTypeConfiguration<Domain.Entities.CompanyEventType.CompanyEventTypeEntity>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.CompanyEventType.CompanyEventTypeEntity> builder)
    {
        builder.HasMany(a => a.Employees)
            .WithOne(x => x.EventType)
            .HasForeignKey(x => x.EventTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(a => a.Events)
            .WithOne(x => x.Type)
            .HasForeignKey(x => x.TypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}