using AutoMapper;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Entities.DTO;
using Ecommerce.Core.IRepo;
using Ecommerce.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ecommarce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork<Products> unitOfWork;
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public ApiResponse apiResponse;

        public OrdersController(IUnitOfWork<Products> unitOfWork, AppDbContext context, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.context = context;
            this.mapper = mapper;
            this.apiResponse = new ApiResponse();

        }

        [HttpGet("GetAllByUserId")]
        public async Task<ActionResult<ApiResponse>> GetAllByUserId(int Id, int P_Size = 10, int P_Number = 1)
        {
            var orders = await unitOfWork.ordersRepo.GetAllByUserId(PSize: P_Size, PNumber: P_Number, id: Id);
                var mappedOrders = mapper.Map<List<Orders>, List<OrdersDTO>>(orders);

            var check = mappedOrders.Any();
            if (check)
            {
                apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                apiResponse.IsSuccess = check;

                apiResponse.Result = mappedOrders;
                return apiResponse;
            }
            else
            {
                apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                apiResponse.IsSuccess = check;
                apiResponse.Error = "Thare is no products";
                return apiResponse;

            }
        }




    }
}
