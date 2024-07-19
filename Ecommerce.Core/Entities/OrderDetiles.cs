using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class OrderDetiles
    {
        public int Id {  get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public decimal Price{ get; set; }

        public decimal Quantity { get; set; }
      public virtual Orders? Order { get; set; }
        public virtual Products? Product { get; set; }
    
    }
}
