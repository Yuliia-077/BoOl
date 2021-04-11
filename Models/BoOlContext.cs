using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BoOl.Models
{
    public class BoOlContext : IdentityDbContext<User>
    {
        public DbSet<Position> Positions { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomService> CustomServices { get; set; }
        public DbSet<Model> Models  { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services  { get; set; }
        public DbSet<Storage> Storages { get; set; }


    public BoOlContext(DbContextOptions<BoOlContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
