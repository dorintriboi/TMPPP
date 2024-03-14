using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfigurations.SpectacleTeamEntity;

public class SpectacleTeamEntityConfigurations: IEntityTypeConfiguration<Domain.Entities.SpectacleTeam.SpectacleTeamEntity>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.SpectacleTeam.SpectacleTeamEntity> builder)
    {
        builder.HasOne(a => a.Team)
            .WithMany(x => x.Spectacles)
            .HasForeignKey(x => x.TeamId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(a => a.Spectacle)
            .WithMany(x => x.Teams)
            .HasForeignKey(x => x.SpectacleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}