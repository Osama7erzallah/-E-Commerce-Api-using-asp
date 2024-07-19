using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepo;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repo
{
    public class ProductsRepo : GenericRepo<Products>, IProductsRepo
    {
        public readonly AppDbContext context;

        public ProductsRepo(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Products>> GetAllProductsByCategoryId(int Id) { 


var products = await context.Products.Include(x => x.Category)
.Where(c => c.CategoryId==Id).
ToListAsync();
return products;
}


    }
}
