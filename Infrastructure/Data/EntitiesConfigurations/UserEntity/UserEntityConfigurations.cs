using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfigurations.UserEntity;

public class UserEntityConfigurations: IEntityTypeConfiguration<Domain.Entities.User.UserEntity>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.User.UserEntity> builder)
    {
        builder.HasOne(a => a.Employee)
            .WithOne(x => x.User)
            .HasForeignKey<Domain.Entities.Employee.EmployeeEntity>(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}