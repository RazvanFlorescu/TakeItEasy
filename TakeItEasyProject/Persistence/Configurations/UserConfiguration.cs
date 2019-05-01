using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class UserConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.Password)
                .IsRequired();

        }
    }
}