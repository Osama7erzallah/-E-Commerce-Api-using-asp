using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities.ViewDTO
{
    public class ProductsFormDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? image { get; set; }
        public int CategoryId { get; set; }
    }
}
