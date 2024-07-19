using Ecommerce.Core.IRepo;
using Ecommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repo
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            productsRepo = new ProductsRepo(context);
            ordersRepo = new OrdersRepo(context);

        }

        public IProductsRepo productsRepo { get ; set; }
        public IOrdersRepo ordersRepo { get; set; }
        public async Task<int> Save() => await context.SaveChangesAsync();        
    }
}
