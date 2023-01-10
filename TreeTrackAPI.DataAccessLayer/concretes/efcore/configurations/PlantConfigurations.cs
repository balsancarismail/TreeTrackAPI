using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreeTrackAPI.Domain.concretes;

namespace TreeTrackAPI.DataAccessLayer.concretes.efcore.configurations
{
    public class PlantConfigurations : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Location).IsRequired(false);
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            builder.HasKey(p => p.Id);

            // 1-to-many relation between Garden and Plant
            builder.HasOne(p => p.Garden).WithMany(g => g.Plants).HasForeignKey(p => p.GardenId).IsRequired();
        }
    }
}
