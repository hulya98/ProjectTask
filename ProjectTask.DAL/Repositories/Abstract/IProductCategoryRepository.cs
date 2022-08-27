using ProjectTask.Domains.Models;
using System;
using System.Collections.Generic;
using ProjectTask.Domains.Dtos;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.DAL.Repositories.Abstract
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        void DeleteProductCategory(int id);
    }
}
