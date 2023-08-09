using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BulkyDbContext _bulkyDbContext;

        public CategoryRepository Category { get; private set; }

        public UnitOfWork(BulkyDbContext bulkyDbContext)
        {
            _bulkyDbContext = bulkyDbContext;
            Category = new CategoryRepository(_bulkyDbContext);
        }

        public void Save()
        {
            _bulkyDbContext.SaveChanges();
        }
    }
}
