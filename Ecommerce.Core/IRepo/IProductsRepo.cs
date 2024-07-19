using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.IRepo
{
    public interface IProductsRepo: IGenericRepo<Products>
    {
        public  Task<IEnumerable<Products>> GetAllProductsByCategoryId (int Cat_Id);
        


        }
    }
