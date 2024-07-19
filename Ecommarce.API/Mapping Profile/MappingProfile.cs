using AutoMapper;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Entities.DTO;
using Ecommerce.Core.Entities.ViewDTO;
using Ecommerce.Infrastructure.Data;

namespace Ecommarce.API.Mapping_Profile
{
    public class MappingProfile : Profile
    {

        public MappingProfile() { 

        CreateMap<Products,ProductsDTO>().
                ForMember(To=>To.CategoryName,
                from => from.MapFrom(c=>c.Category!=null ? c.Category.Name : null));

            CreateMap<Orders, OrdersDTO>().ReverseMap();
            CreateMap<Products, ProductsFormDTO>().ReverseMap();



        }

    }
}
