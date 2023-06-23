using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky
{
    public class BulkyDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public BulkyDbContext(DbContextOptions<BulkyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new List<Category>
                {
                     new Category { CategoryId = 1, CategoryName = "Healthcare", DisplayOrder = 1 },
                     new Category { CategoryId = 2, CategoryName = "Beauty", DisplayOrder = 3 },
                     new Category { CategoryId = 3, CategoryName = "Science", DisplayOrder = 2 }
                }
             );
        }
    }
}
