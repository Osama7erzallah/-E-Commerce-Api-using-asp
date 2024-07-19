using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class LocalUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone{ get; set; }

        public string Role { get; set; }
        public virtual ICollection<Orders> Orders { get; set; } = new HashSet<Orders>();


    }
}
