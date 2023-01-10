using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreeTrackAPI.Domain.concretes;

namespace TreeTrackAPI.DataAccessLayer.concretes.efcore.configurations
{
    public class NoteConfigurations : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.Property(n => n.Title).IsRequired();
            builder.Property(n => n.Title).IsRequired(false);
            builder.Property(n => n.Image).IsRequired(false);
            builder.Property(n => n.CreatedAt).IsRequired().HasDefaultValueSql("getdate()");

            builder.HasKey(n => n.Id);
        }
    }
}
