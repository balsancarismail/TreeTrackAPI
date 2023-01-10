using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreeTrackAPI.Domain.concretes;

namespace TreeTrackAPI.DataAccessLayer.concretes.efcore.configurations
{
    public class GardenConfigurations : IEntityTypeConfiguration<Garden>
    {
        public void Configure(EntityTypeBuilder<Garden> builder)
        {
            builder.Property(g => g.GardenName).IsRequired();
            builder.Property(g => g.CreatedAt).IsRequired();
            builder.Property(g => g.Area).IsRequired(false);
            builder.Property(g => g.Polygon).IsRequired(false);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            builder.HasKey(g => g.Id);
            builder.HasMany(g => g.Plants).WithOne(p => p.Garden).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
