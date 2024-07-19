using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class Orders
    {
        public int Id {  get; set; }
        [ForeignKey(nameof(LocalUser))]
        public int LocalUserId{ get; set; }

        public string OrderStatus{ get; set; }
        public DateTime OrderDate { get; set; }
        public virtual LocalUser? LocalUser { get; set; }
        public virtual ICollection<OrderDetiles>? OrderDetiles { get; set; } = new HashSet<OrderDetiles>();


    }
}
