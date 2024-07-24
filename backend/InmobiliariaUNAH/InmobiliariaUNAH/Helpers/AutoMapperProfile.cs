using AutoMapper;
using InmobiliariaUNAH.Database.Entities;
using InmobiliariaUNAH.Dtos.CategoriesProduct;
using InmobiliariaUNAH.Dtos.Notes;
using InmobiliariaUNAH.Dtos.Products;
namespace InmobiliariaUNAH.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForProducts();
            MapsForCategoriesProducts();
            MapsForNotes();
        }

        private void MapsForProducts()
        {
            CreateMap<ProductEntity, ProductDto>()
           .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category)); // Mapea la propiedad Category para mostrar en un {}


            // para las demas normales
            CreateMap<ProductCreateDto, ProductEntity>();
            CreateMap<ProductEditDto, ProductEntity>();
        }

        private void MapsForCategoriesProducts()
        {
            CreateMap<CategoryProductEntity, CategoryProductDto>();
            CreateMap<CategoryProductEntity, CategoryProductCreateDto>();
            CreateMap<CategoryProductEntity, CategoryProductEditDto>();

            CreateMap<CategoryProductCreateDto, CategoryProductEntity>();
            CreateMap<CategoryProductEditDto, CategoryProductEntity>();
        }
        private void MapsForNotes()
        {
            CreateMap<NoteEntity, NoteDto>();
            CreateMap<NoteCreateDto, NoteEntity>();
            CreateMap<NoteEditDto, NoteEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
   
    }
}