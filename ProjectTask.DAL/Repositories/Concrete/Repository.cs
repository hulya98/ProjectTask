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
        protected Context _context { get; set; }
        private DbSet<T> _dbSet;
        public Repository(Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
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
