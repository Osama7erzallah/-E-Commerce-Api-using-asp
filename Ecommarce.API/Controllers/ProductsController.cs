using AutoMapper;
using Ecommarce.API.Mapping_Profile;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Entities.DTO;
using Ecommerce.Core.Entities.ViewDTO;
using Ecommerce.Core.IRepo;
using Ecommerce.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommarce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork<Products> unitOfWork;
        private readonly IMapper mapper;
        public ApiResponse apiResponse;

        public ProductsController(IUnitOfWork<Products> unitOfWork,IMapper mapper)
        {
           
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.apiResponse = new ApiResponse();
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllProducts(int P_Size = 10, int P_Number = 1)
        {
            var products =await unitOfWork.productsRepo.GetAll(PSize:P_Size,PNumber:P_Number,InclodeP:"Category");
            var check = products.Any();
            if (check) {
            apiResponse.StatusCode=System.Net.HttpStatusCode.OK;
                apiResponse.IsSuccess = check;
                var maping =mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(products);
                apiResponse.Result = maping;
            return apiResponse;
            }
            else {
                apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                apiResponse.IsSuccess = check;
                apiResponse.Error="Thare is no products";
                return apiResponse;

            }
            
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<ApiResponse>> GetById(int id)
        {
            var products = await unitOfWork. productsRepo.GetById (id);
            var check = (products != null);
            if (check)
            {
                apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                apiResponse.IsSuccess = check;
                var mapping= mapper.Map<Products, ProductsDTO>(products);
                apiResponse.Result = mapping;
                return apiResponse;
            }
            else
            {
                apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                apiResponse.IsSuccess = check;
                apiResponse.Error = "Thare is no products";
                return apiResponse;

            }
            return Ok(products);
        }

        [HttpGet("GetAllProductsByCategoryId")]
        public async Task<ActionResult<ApiResponse>> GetAllProductsByCategoryId(int Id )
        {
            var products = await unitOfWork.productsRepo.GetAllProductsByCategoryId(Id);
            var check = products.Any();
            if (check)
            {
                apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                apiResponse.IsSuccess = check;
                var maping = mapper.Map<IEnumerable<Products>, IEnumerable<ProductsDTO>>(products);
                apiResponse.Result = maping;
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



        [HttpPost]
        public async Task<ActionResult> Create(ProductsFormDTO productsFormDTO) {
            Products product= mapper.Map<ProductsFormDTO, Products>(productsFormDTO);

            await unitOfWork.productsRepo.Create(product);
            await unitOfWork.Save();
            return Ok(productsFormDTO);
        }


        [HttpPut]
   
        public async Task<ActionResult> Update(ProductsDTO productsDTO)
        {
            var Product = await unitOfWork.productsRepo.GetById(productsDTO.Id);
            if (Product == null)
            {
                return NotFound("Product not found.");
            }

            var updatedProduct = mapper.Map(productsDTO, Product);


            unitOfWork.productsRepo.Update(updatedProduct);
            await unitOfWork.Save();
            return Ok(updatedProduct);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var Product = await unitOfWork.productsRepo.GetById(id);
            if (Product == null)
            {
                return NotFound("Product not found.");
            }

            unitOfWork.productsRepo.Delete(id);
           await  unitOfWork.Save();
            return Ok("The Product Deleted successfully");
        }
    }
}
