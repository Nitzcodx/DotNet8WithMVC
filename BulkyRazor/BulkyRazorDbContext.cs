using BulkyRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyRazor
{
    public class BulkyRazorDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public BulkyRazorDbContext(DbContextOptions options) : base(options)
        {   }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new List<Category>
                    {
                         new Category { Id = 1, Name = "Healthcare", DisplayOrder = 1 },
                         new Category { Id = 2, Name = "Beauty", DisplayOrder = 3 },
                         new Category { Id = 3, Name = "Science", DisplayOrder = 2 }
                    }
                );
        }
    }
}
