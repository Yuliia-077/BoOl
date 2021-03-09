using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BoOl.Models
{
    public class BoOlContext: DbContext
    {
        public DbSet<Position> Positions { get; set; }
        public DbSet<Worker> Workers { get; set; }

        public BoOlContext(DbContextOptions<BoOlContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
