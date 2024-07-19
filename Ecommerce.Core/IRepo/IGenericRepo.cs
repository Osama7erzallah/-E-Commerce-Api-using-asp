using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.IRepo
{
    public interface IGenericRepo<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll(String? InclodeP,int PSize=10,int PNumber=1);
        public Task<T> GetById(int id);
        public Task Create(T Model);
        public void Update(T Model);
        public void Delete(int id);
    }
}
