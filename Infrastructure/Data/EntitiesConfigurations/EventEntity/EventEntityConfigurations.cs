using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfigurations.EventEntity;

public class EventEntityConfigurations: IEntityTypeConfiguration<Domain.Entities.Event.EventEntity>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Event.EventEntity> builder)
    {
        builder.HasOne(a => a.Institution)
            .WithMany(x => x.Events)
            .HasForeignKey(x => x.InstitutionId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(a => a.Team)
            .WithMany(x => x.Events)
            .HasForeignKey(x => x.TeamId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(a => a.Spectacle)
            .WithMany(x => x.Events)
            .HasForeignKey(x => x.SpectacleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}