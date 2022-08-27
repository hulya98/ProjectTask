﻿using AutoMapper;
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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private DbSet<Product> _dbSet;
        public ProductRepository(ProductContext productContext) : base(productContext)
        {
            _productContext = productContext;
            _dbSet = _productContext.Set<Product>();

        }

        public List<Product> GetProducts()
        {
            var products = _productContext.Products.Where(p => !p.IsDeleted).ToList();
            return products;
        }

    
    }
}
