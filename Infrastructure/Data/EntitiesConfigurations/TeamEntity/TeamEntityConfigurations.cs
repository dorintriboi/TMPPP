using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfigurations.TeamEntity;

public class TeamEntityConfigurations: IEntityTypeConfiguration<Domain.Entities.Team.TeamEntity>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Team.TeamEntity> builder)
    {
        builder.HasMany(a => a.Events)
            .WithOne(x => x.Team)
            .HasForeignKey(x => x.TeamId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(a => a.Members)
            .WithOne(x => x.Team)
            .HasForeignKey(x => x.TeamId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}