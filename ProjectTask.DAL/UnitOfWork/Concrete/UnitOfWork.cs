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
        private ProductContext _productContext;
        private ProductStockContext _productStockContext;
        public UnitOfWork(ProductContext productContext)
        {
            _productContext = productContext;
            ProductCategoryRepository = new ProductCategoryRepository(_productContext);
            ProductRepository = new ProductRepository(_productContext);
        }

        public UnitOfWork(ProductStockContext productStockContext)
        {
            _productStockContext = productStockContext;
            ProductStockRepository = new ProductStockRepository(_productStockContext);

        }
        public IProductStockRepository ProductStockRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }

        public IProductCategoryRepository ProductCategoryRepository { get; set; }

        public int CompleteProduct()
        {
            return _productContext.SaveChanges();
        }

        public int CompleteProductStock()
        {
            return _productStockContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_productContext != null)
                _productContext.Dispose();
            else
                _productStockContext.Dispose();
        }
    }
}
