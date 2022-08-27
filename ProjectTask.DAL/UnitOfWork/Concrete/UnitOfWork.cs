using AutoMapper;
using ProjectTask.DAL.Repositories.Abstract;
using ProjectTask.DAL.Repositories.Concrete;
using ProjectTask.DAL.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.DAL.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProductContext _context;
        public UnitOfWork(ProductContext context)
        {
            _context = context;
            ProductCategoryRepository = new ProductCategoryRepository(_context);
            ProductRepository = new ProductRepository(_context);
        }
        public IProductRepository ProductRepository { get; set; }

        public IProductCategoryRepository ProductCategoryRepository { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
