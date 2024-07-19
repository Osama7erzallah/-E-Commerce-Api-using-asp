using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.IRepo
{
    public interface IOrdersRepo : IGenericRepo<Orders>
    {
        public Task<List<Orders>> GetAllByUserId(int id,int PSize=10,int PNumber=1);
        
    }
}
