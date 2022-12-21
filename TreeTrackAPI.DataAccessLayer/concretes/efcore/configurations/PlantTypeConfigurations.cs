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
    public class PlantTypeConfigurations : IEntityTypeConfiguration<PlantType>
    {
        public void Configure(EntityTypeBuilder<PlantType> builder)
        {
            builder.Property(pt => pt.Name).IsRequired();

            builder.HasKey(pt => pt.Id);
            builder.HasMany(pt => pt.Plants).WithOne(p => p.PlantType);
        }
    }
}
