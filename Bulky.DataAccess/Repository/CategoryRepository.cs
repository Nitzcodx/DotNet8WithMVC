using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly BulkyDbContext _bulkyDbContext;

        public CategoryRepository(BulkyDbContext bulkyDbContext) : base(bulkyDbContext)
        {
            _bulkyDbContext = bulkyDbContext;
        }

        public void Save()
        {
            _bulkyDbContext.SaveChanges();
        }

        public void Update(Category category)
        {
            _bulkyDbContext.Categories.Update(category);
        }
    }
}
