using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTrackAPI.Domain.concretes;
using System.Reflection.Emit;

namespace TreeTrackAPI.DataAccessLayer.concretes.efcore.configurations
{
    public class UserGardenConfigurations : IEntityTypeConfiguration<UserGarden>
    {
        public void Configure(EntityTypeBuilder<UserGarden> builder)
        {
            builder.HasKey(ug => ug.Id);
            builder.HasOne(ug => ug.User).WithMany(u => u.Gardens).HasForeignKey(ug => ug.UserId);
            builder.HasOne(ug => ug.Garden).WithMany(g => g.Users).HasForeignKey(ug => ug.GardenId);
        }
    }
}
