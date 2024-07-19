using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class ApiResponse
    {
        public  HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public object Result { get; set; }
    }
}
