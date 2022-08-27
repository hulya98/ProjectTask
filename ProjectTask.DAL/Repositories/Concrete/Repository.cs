using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectTask.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.DAL.Repositories.Concrete
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected ProductContext _productContext { get; set; }
        protected ProductStockContext _productStockContext { get; set; }
        private DbSet<T> _dbSet;
        public Repository(ProductContext productContext)
        {
            _productContext = productContext;
            _dbSet = _productContext.Set<T>();
        }

        public Repository(ProductStockContext productStockContext)
        {
            _productStockContext = productStockContext;
            _dbSet = _productStockContext.Set<T>();
        }

        public List<T> GetAll()
        {
            var getAllList = _dbSet.ToList();
            return getAllList;
        }

        public T Get(int id)
        {
            var getRow = _dbSet.Find(id);
            return getRow;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(int id)
        {
            var getRow = Get(id);
            _dbSet.Remove(getRow);
        }
    }
}
