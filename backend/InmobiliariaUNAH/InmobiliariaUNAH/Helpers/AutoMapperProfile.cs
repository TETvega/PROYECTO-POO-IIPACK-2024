using AutoMapper;
using InmobiliariaUNAH.Database.Entities;
using InmobiliariaUNAH.Dtos.CategoriesProduct;
using InmobiliariaUNAH.Dtos.Notes;
using InmobiliariaUNAH.Dtos.Products;
using InmobiliariaUNAH.Dtos.ClientType;
using InmobiliariaUNAH.Dtos.Events;
using InmobiliariaUNAH.Dtos.Events.Helper_Dto;
using InmobiliariaUNAH.Dtos.Detail;
namespace InmobiliariaUNAH.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForProducts();
            MapsForCategoriesProducts();
            MapsForNotes();
            MapsForClientsTypes();
            MapsForEvents();
        }

        private void MapsForEvents()
        {
            CreateMap<EventCreateDto, EventEntity>()
                .ForMember(dest => dest.EventDetails, opt => opt.Ignore());// esta ignorando por que cuando lo crea se guarda solamente los detalles primeros y despues se le anexa

            CreateMap<EventEditDto, EventEntity>()
                .ForMember(dest => dest.EventDetails, opt => opt.Ignore());

            CreateMap<EventEntity, EventDto>()
                .ForMember(dest => dest.EventDetails, opt => opt.MapFrom(src => src.EventDetails));
    

            // para poder ver los detalles no se si los podia poner aqui pero los meti
            CreateMap<DetailEntity, DetailDto>()
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));

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

        private void MapsForClientsTypes()
        {
            CreateMap<ClientTypeEntity, ClientTypeDto>();
            CreateMap<ClientTypeEntity, ClientTypeCreateDto>();
            CreateMap<ClientTypeEntity, ClientTypeEditDto>();

            CreateMap<ClientTypeCreateDto, ClientTypeEntity>();
            CreateMap<ClientTypeEditDto, ClientTypeEntity>();
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