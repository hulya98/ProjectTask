using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectTask.DAL;
using ProjectTask.DAL.Repositories.Abstract;
using ProjectTask.DAL.Repositories.Concrete;
using ProjectTask.DAL.UnitOfWork.Abstract;
using ProjectTask.DAL.UnitOfWork.Concrete;
using ProjectTask.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTask.API.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
        
        public static void ConfigureMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Product));
            services.AddAutoMapper(typeof(ProductCategory));
        }

       

    }
}
