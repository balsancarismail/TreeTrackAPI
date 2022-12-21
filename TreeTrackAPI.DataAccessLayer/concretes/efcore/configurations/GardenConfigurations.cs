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
    public class GardenConfigurations : IEntityTypeConfiguration<Garden>
    {
        public void Configure(EntityTypeBuilder<Garden> builder)
        {
            builder.Property(g => g.GardenName).IsRequired();
            builder.Property(g => g.CreatedAt).IsRequired();
            builder.Property(g => g.Area).IsRequired(false);

            builder.HasKey(g => g.Id);
            builder.HasMany(g => g.Plants).WithOne(p => p.Garden).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(g => g.Users).WithMany(u => u.Gardens);
            builder.HasMany(g => g.Locations).WithOne(l => l.Garden);
        }
    }
}
