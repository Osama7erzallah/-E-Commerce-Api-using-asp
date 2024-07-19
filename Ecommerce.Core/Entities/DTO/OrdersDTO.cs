using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities.DTO
{
    public class OrdersDTO
    {
        public int Id { get; set; }
        public string OrderStatus { get; set; } = default!;
        public DateTime OrderDate { get; set; }
    }

}

