using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTrackAPI.Domain.concretes;

namespace TreeTrackAPI.DataAccessLayer.concretes.efcore.configurations
{
    public class PlantConfigurations : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Point).IsRequired(false);
            builder.Property(p => p.CreatedAt).IsRequired();

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.PlantType).WithMany(pt => pt.Plants).IsRequired();
            builder.HasOne(p => p.Garden).WithMany(g => g.Plants).IsRequired();
        }
    }
}
