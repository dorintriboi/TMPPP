using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfigurations.InstitutionEntity;

public class InstitutionEntityConfigurations: IEntityTypeConfiguration<Domain.Entities.Institution.InstitutionEntity>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Institution.InstitutionEntity> builder)
    {
        builder.HasMany(a => a.Events)
            .WithOne(x => x.Institution)
            .HasForeignKey(x => x.InstitutionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}