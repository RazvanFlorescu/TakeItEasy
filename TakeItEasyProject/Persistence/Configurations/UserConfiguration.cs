using DataAccess.Write.Configurations.Entities;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class UserConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.Password)
                .IsRequired();

        }
    }
}