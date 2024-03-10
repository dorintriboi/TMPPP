using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfigurations.SpectacleEntity;

public class SpectacleEntityConfigurations: IEntityTypeConfiguration<Domain.Entities.Spectacle.SpectacleEntity>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Spectacle.SpectacleEntity> builder)
    {
        builder.HasMany(a => a.Events)
            .WithOne(x => x.Spectacle)
            .HasForeignKey(x => x.SpectacleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}