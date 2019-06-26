using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class ImageConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.Content)
                .IsRequired(false);

            builder.HasOne<User>().WithOne()
                .HasForeignKey<User>(p => p.ImageId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne<Vacation>().WithOne()
                .HasForeignKey<Vacation>(p => p.ImageId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}