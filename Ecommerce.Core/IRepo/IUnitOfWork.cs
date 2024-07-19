using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.IRepo
{
    public interface IUnitOfWork<T> where T : class
    {
        public IProductsRepo productsRepo { get; set; }
        public IOrdersRepo ordersRepo { get; set; }


        public Task<int> Save();
    }
}
