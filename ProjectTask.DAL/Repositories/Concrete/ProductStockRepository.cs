using Microsoft.EntityFrameworkCore;
using ProjectTask.DAL.Repositories.Abstract;
using ProjectTask.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.DAL.Repositories.Concrete
{
    public class ProductStockRepository : Repository<ProductStock>, IProductStockRepository
    {
        private DbSet<ProductStock> _dbSet;
        public ProductStockRepository(ProductStockContext productStockContext) : base(productStockContext)
        {
            _productStockContext = productStockContext;
            _dbSet = _productStockContext.Set<ProductStock>();
        }
    
        public void AddStock(ProductStock productStock)
        {
        }

        public void RemoveStock(ProductStock productStock)
        {

        }
    }
}
