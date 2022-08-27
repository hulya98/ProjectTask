using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Domains.Dtos
{
    public class RemoveProductStock
    {
        public int NewSoldProductCount { get; set; }
        public int ProductId { get; set; }
    }
}
