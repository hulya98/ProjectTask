using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Domains.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal Price { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public string State { get; set; }
        public bool IsDeleted { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
