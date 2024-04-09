using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfigurations.PlaylistEntity;

public class PlaylistEntityConfigurations: IEntityTypeConfiguration<Domain.Entities.Playlist.PlaylistEntity>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Playlist.PlaylistEntity> builder)
    {
        builder.HasMany(a => a.Spectales)
            .WithOne(x => x.Playlist)
            .HasForeignKey(x => x.PlaylistId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}