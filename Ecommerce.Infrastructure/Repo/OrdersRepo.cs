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
    public class OrdersRepo : GenericRepo<Orders>, IOrdersRepo
    {
        public readonly AppDbContext context;

        public OrdersRepo(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Orders>> GetAllByUserId(int id, int PSize = 10, int PNumber = 1)
        {
            IQueryable<Orders> model = context.Orders.Include(c=>c.LocalUser).Where(x => x.LocalUserId == id);
           // var model =  context.Orders.Where(x => x.LocalUserId == id);
            if (PSize > 0)
            {
                if (PSize > 10)
                    PSize = 10;
                model = model.Skip(PSize * (PNumber - 1)).Take(PSize);
            }
            return await model.ToListAsync();
    }
    }
}