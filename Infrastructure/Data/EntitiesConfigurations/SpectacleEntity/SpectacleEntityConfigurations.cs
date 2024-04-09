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
        
        builder.HasMany(a => a.Teams)
            .WithOne(x => x.Spectacle)
            .HasForeignKey(x => x.SpectacleId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(a => a.Playlist)
            .WithMany(x => x.Spectales)
            .HasForeignKey(x => x.PlaylistId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}