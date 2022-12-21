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
    public class NoteConfigurations : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.Property(n => n.Title).IsRequired();
            builder.Property(n => n.Title).IsRequired(false);
            builder.Property(n => n.Image).IsRequired(false);
            builder.Property(n => n.Date).IsRequired();

            builder.HasKey(n => n.Id);
            builder.HasOne(n=>n.Plant).WithMany(p => p.Notes).IsRequired(false);
            builder.HasOne(n=>n.Garden).WithMany(p => p.Notes).IsRequired(false);
        }
    }
}
