using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdminApp.Models;
using AdminApp.Configurations;
using System.Reflection;

namespace AdminApp.Data
{
    public class AdminAppDbContext : DbContext
    {
        public AdminAppDbContext (DbContextOptions<AdminAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<AdminApp.Models.Post> Posts { get; set; } = default!;
        public DbSet<AdminApp.Models.Category> Categories { get; set; } = default!;
        public DbSet<AdminApp.Models.PopularTag> PopularTags { get; set; } = default!;

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship between Post and PopularTag

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
