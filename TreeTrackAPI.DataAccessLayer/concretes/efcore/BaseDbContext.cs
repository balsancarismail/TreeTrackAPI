using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using TreeTrackAPI.Domain.concretes;

namespace TreeTrackAPI.DataAccessLayer.concretes.efcore
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Garden> Gardens { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantType> PlantTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGarden> UserGardens { get; set; }

        public BaseDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TreeTrack;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", opt =>
                {
                    opt.MigrationsAssembly("TreeTrackAPI.DataAccessLayer");
                    opt.UseNetTopologySuite();
                });
            }
        }
        public override ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        {
            ChangeTracker.Entries().ToList().ForEach(entry =>
            {
                if (entry.GetType().IsEquivalentTo(typeof(Garden)) && entry.State == EntityState.Added)
                {
                    ((Garden)entry.Entity).CreatedAt = DateTime.UtcNow;
                }
                else if (entry.GetType().IsEquivalentTo(typeof(Garden)) && entry.State == EntityState.Modified)
                {
                    ((Garden)entry.Entity).UpdatedAt = DateTime.UtcNow;
                }
            });
            return base.AddAsync(entity, cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseDbContext).Assembly);
        }
    }
}
