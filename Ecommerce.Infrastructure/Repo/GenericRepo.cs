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
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext context;

        public GenericRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Create(T Model)
        {
            await context.Set<T>().AddAsync(Model);
        }

        public void Delete(int id)
        {
            var model =
            context.Set<T>().Find(id);
            context.Set<T>().Remove(model);
        }

        public async Task<IEnumerable<T>> GetAll(String? InclodeP, int PSize = 10, int PNumber = 1)
        {
           


            IQueryable<T> all =  context.Set<T>();
            if (InclodeP != null)
            {
                foreach (var item in InclodeP.Split(',',StringSplitOptions.RemoveEmptyEntries))
                {
                    all = all.Include(item);
                }

            }
            if (PSize > 0)
            {
                if(PSize > 10) 
                PSize = 10;
                    all = all.Skip(PSize * (PNumber - 1)).Take(PSize);

                
            }
            return await all.ToListAsync();
}

        public async Task<T> GetById(int id)
        {

            return await context.Set<T>().FindAsync (id);

        }

        public void Update(T Model)
        {
            context.Set<T>().Update(Model);

        }
    }
}
