using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LocationConfiguration: BaseEntityConfiguration, IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(p => p.Latitude)
                .IsRequired();

            builder.Property(p => p.Longitude)
                .IsRequired();

            builder.Property(p => p.LocationType)
                .IsRequired();

            builder.Property(p => p.Address)
                .IsRequired();
        }
    }
}
