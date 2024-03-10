using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfigurations.TeamMemberEntity;

public class TeamMemberEntityConfigurations : IEntityTypeConfiguration<Domain.Entities.TeamMember.TeamMemberEntity>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.TeamMember.TeamMemberEntity> builder)
    {
        builder.HasOne(a => a.Employee)
            .WithMany(x => x.Teams)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Team)
            .WithMany(x => x.Members)
            .HasForeignKey(x => x.TeamId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}