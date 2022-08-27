using ProjectTask.Domains.Dtos;
using ProjectTask.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.DAL.Repositories.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetProducts();
        Product GetProductIsNotDeleted(int id);
    }
}
