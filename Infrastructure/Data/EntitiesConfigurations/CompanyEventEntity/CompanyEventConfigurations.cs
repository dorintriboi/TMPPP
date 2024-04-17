using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfigurations.CompanyEventEntity;

public class CompanyEventConfigurations: IEntityTypeConfiguration<Domain.Entities.CompanyEvent.CompanyEventEntity>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.CompanyEvent.CompanyEventEntity> builder)
    {
        builder.HasOne(a => a.Type)
            .WithMany(x => x.Events)
            .HasForeignKey(x => x.TypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}