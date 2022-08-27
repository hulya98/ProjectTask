using ProjectTask.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.DAL.Repositories.Abstract
{
    public interface IProductStockRepository : IRepository<ProductStock>
    {
        void AddStock(ProductStock productStock);
        void RemoveStock(ProductStock productStock);
    }
}
