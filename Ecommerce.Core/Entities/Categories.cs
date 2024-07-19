using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }

        public virtual ICollection<Products> Products { get; set; }=new HashSet<Products>();
    }
}
