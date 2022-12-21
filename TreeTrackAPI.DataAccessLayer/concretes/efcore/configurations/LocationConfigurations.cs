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
    public class LocationConfigurations : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(l => l.City).IsRequired();
            builder.Property(l => l.Country).IsRequired();

            builder.HasKey(l => l.Id);
            builder.HasOne(l => l.Garden).WithMany(g => g.Locations).IsRequired(false);

        }
    }
}
