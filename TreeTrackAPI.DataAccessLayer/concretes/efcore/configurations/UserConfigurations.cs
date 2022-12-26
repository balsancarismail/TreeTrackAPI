using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreeTrackAPI.Domain.concretes;

namespace TreeTrackAPI.DataAccessLayer.concretes.efcore.configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Password).IsRequired();

            builder.HasKey(u => u.Id);

            builder.HasMany(u => u.Gardens).WithMany(g => g.Users);
        }
    }
}
