using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class VacationJoiningsConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<VacationJoining>
    {
        public void Configure(EntityTypeBuilder<VacationJoining> builder)
        {
            base.Configure(builder);
        }
    }
}
