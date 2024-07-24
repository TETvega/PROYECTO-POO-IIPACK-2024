using AutoMapper;
using InmobiliariaUNAH.Database.Entities;
using InmobiliariaUNAH.Dtos.CategoriesProduct;
using InmobiliariaUNAH.Dtos.EventDetails;
using InmobiliariaUNAH.Dtos.Events;
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
            MapsForDetails();
            MapsForEvents();
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
            CreateMap<NoteEditDto, NoteEntity>();
        }
        private void MapsForDetails()
        {
            CreateMap<DetailEntity, EventDetailDto>();
            CreateMap<EventDetailCreateDto, DetailEntity>();
            CreateMap<EventDetailEditDto, DetailEntity>();
        }
        private void MapsForEvents()
        {
            CreateMap<EventEntity, EventDto>();
            CreateMap<EventCreateDto, EventEntity>()
                .ForMember(dest => dest.EventDetails, opt => opt.MapFrom(src => src.EventDetails));
            CreateMap<EventEditDto, EventEntity>();
        }
   
    }
}