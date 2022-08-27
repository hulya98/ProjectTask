using Microsoft.EntityFrameworkCore;
using ProjectTask.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.DAL
{
    public class ProductStockContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-2VOS6HP; database = ProductStock; integrated security = true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductStock>(entity =>
            {
                entity.Property(e => e.Count).HasDefaultValueSql("0");
            });
        }

        public DbSet<ProductStock> ProductStock { get; set; }
    }
}
