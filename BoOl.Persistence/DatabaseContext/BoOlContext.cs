using BoOl.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace BoOl.Persistence.DatabaseContext
{
    public class BoOlContext : IdentityDbContext<User>
    {
        private readonly DatabaseOptions _options;

        public BoOlContext(IOptions<DatabaseOptions> options)
        {
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
            if (string.IsNullOrWhiteSpace(_options.SqlConnectionString))
            {
                throw new ArgumentException("Connection string is null or empty");
            }
            //Database.EnsureCreated();
        }

        public DbSet<Position> Positions { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomService> CustomServices { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Storage> Storages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_options.SqlConnectionString, b => b.MigrationsAssembly("BoOl"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
