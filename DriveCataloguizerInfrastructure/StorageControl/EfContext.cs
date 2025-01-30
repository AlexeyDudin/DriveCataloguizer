using System;
using DriveCataloguizerInfrastructure.StorageControl.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DriveCataloguizerInfrastructure.StorageControl
{
    public class EfContext : DbContext
    {
        private readonly string _connectionString;
        public EfContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.Migrate();
        }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(_connectionString))
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlite(connectionString: _connectionString);
                var builder = new SqliteDbContextOptionsBuilder(optionsBuilder);
            }
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CatalogueConfiguration());
            modelBuilder.ApplyConfiguration(new DriveConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogueToDriveConfiguration());
        }
    }
}
