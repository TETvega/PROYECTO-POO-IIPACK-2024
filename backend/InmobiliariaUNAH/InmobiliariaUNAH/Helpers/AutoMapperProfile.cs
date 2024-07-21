using AutoMapper;
using InmobiliariaUNAH.Database.Entities;
using InmobiliariaUNAH.Dtos.CategoriesProduct;
using InmobiliariaUNAH.Dtos.Products;
namespace InmobiliariaUNAH.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForProducts();
    
        }

        private void MapsForProducts()
        {
            CreateMap<ProductEntity, ProductDto>()
           .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category)); // Mapea la propiedad Category para mostrar en un {}

            // Configuración de mapeo para CategoryProductEntity a CategoryProductDto
            CreateMap<CategoryProductEntity, CategoryProductDto>();

            // para las demas normales
            CreateMap<ProductCreateDto, ProductEntity>();
            CreateMap<ProductEditDto, ProductEntity>();
        }

   
    }
}