using BlackBackup.Domain.Entities;
using BlackBackup.Infra.EFCoreSQLite.Configuracao;
using Microsoft.EntityFrameworkCore;

namespace BlackBackup.EFCoreSQLite
{
    public class DataSQLiteContext : DbContext
    {
        private readonly string _connect = $"Data Source={Application.StartupPath}\\Data\\Data.db";
        protected override void OnConfiguring(DbContextOptionsBuilder opts)
        {
            opts.UseSqlite(_connect);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfiguracaoBucket());
            modelBuilder.Entity<Bucket>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
        }

        public DbSet<Bucket> Buckets { get; set; }

        public void DeatchAllEntities()
        {
            var changedEntrieCopy = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();
            foreach (var entry in changedEntrieCopy)
                entry.State = EntityState.Detached;
        }
    }
}
