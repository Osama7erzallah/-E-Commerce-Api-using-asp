using AutoMapper;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Entities.DTO;
using Ecommerce.Core.Entities.FormDTO;
using Ecommerce.Core.Entities.ViewDTO;
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

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAll(int P_Size = 10, int P_Number = 1) {

            var orders = await unitOfWork.ordersRepo.GetAll(PSize: P_Size, PNumber: P_Number, InclodeP: null);

            var check = orders.Any();
            if (check)
            {
                apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                apiResponse.IsSuccess = check;
                var mappedOrders = mapper.Map<IEnumerable<Orders>, IEnumerable<OrdersDTO>>(orders);
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

        [HttpGet("GetOrderById")]
        public async Task<ActionResult<ApiResponse>> GetOrderById(int Id)
        {
            var order = await unitOfWork.ordersRepo.GetById(Id);
            var check = order != null;
            if (check)
            {
                apiResponse.StatusCode = HttpStatusCode.OK;
                apiResponse.IsSuccess = check;
                var mappedOrders =  mapper.Map<Orders, OrdersDTO>(order);
                apiResponse.Result = mappedOrders;
                return apiResponse;

            }

            else
            {

                apiResponse.StatusCode = HttpStatusCode.OK;
                apiResponse.IsSuccess = check;
                apiResponse.Error = "Thare is no products";
                return apiResponse;
            }

        }

        [HttpPost]
        public async Task<ActionResult> CreatOrder(OrdersFormDTO ordersFormDTO)
        {
            var mappingOrder = mapper.Map<OrdersFormDTO, Orders>(ordersFormDTO);
            await unitOfWork.ordersRepo.Create(mappingOrder);
            await unitOfWork.Save();
            return Ok(mappingOrder);
        }

        [HttpPut]

        public async Task<ActionResult> Update(OrdersDTO ordersDTO)
        {
            var orders = await unitOfWork.ordersRepo.GetById(ordersDTO.Id);
            if (orders == null)
            {
                return NotFound("order not found.");
            }

            var updatedOrder = mapper.Map(ordersDTO, orders);


            unitOfWork.ordersRepo.Update(updatedOrder);
            await unitOfWork.Save();
            return Ok(updatedOrder);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var Order = await unitOfWork.ordersRepo.GetById(id);
            if (Order == null)
            {
                return NotFound("Order not found.");
            }

            unitOfWork.ordersRepo.Delete(id);
            await unitOfWork.Save();
            return Ok("The Order Deleted successfully");
        }

    }
    }
