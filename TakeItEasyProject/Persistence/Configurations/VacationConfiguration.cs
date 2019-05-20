using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class VacationConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Vacation>
    {
        public void Configure(EntityTypeBuilder<Vacation> builder)
        {
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(20);

            builder.OwnsOne(p => p.StartPoint);

            builder.OwnsOne(p => p.Destination);

            builder.Property(p => p.StartDate)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.EndDate)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
