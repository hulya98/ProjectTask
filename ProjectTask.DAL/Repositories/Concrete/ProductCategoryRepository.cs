using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectTask.DAL.Repositories.Abstract;
using ProjectTask.Domains.Dtos;
using ProjectTask.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.DAL.Repositories.Concrete
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        private DbSet<ProductCategory> _dbSet;
        public ProductCategoryRepository(Context context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<ProductCategory>();
        }

     
        void IProductCategoryRepository.DeleteProductCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
