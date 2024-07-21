using AutoMapper;
using InmobiliariaUNAH.Database.Entities;
using InmobiliariaUNAH.Dtos.Products;
namespace InmobiliariaUNAH.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForProducts();
            MapsForCategoriesProducts();
        }

        private void MapsForProducts()
        {
            CreateMap<ProductEntity, ProductDto>();
            CreateMap<ProductCreateDto, ProductEntity>();
            CreateMap<ProductEditDto, ProductEntity>();
        }

        private void MapsForCategoriesProducts() // Falta Modificar esto y aplicarlo en el servicio de Productos
        {
            CreateMap<CategoryProductEntity, ProductDto>();
            CreateMap<ProductCreateDto, ProductEntity>();
            CreateMap<ProductEditDto, ProductEntity>();
        }
    }
}