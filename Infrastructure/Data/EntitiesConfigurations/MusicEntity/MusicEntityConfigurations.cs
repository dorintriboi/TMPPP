using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfigurations.MusicEntity;

public class MusicEntityConfigurations: IEntityTypeConfiguration<Domain.Entities.Music.MusicEntity>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Music.MusicEntity> builder)
    {
    }
}