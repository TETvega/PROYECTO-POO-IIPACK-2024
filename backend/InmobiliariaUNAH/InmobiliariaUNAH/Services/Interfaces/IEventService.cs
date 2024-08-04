using InmobiliariaUNAH.Dtos.CategoriesProduct;
using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Events;

namespace InmobiliariaUNAH.Services.Interfaces
{
    public interface IEventService
    {

        Task<ResponseDto<EventDto>> CreateEvent(EventCreateDto dto);
        Task<ResponseDto<EventDto>> GeEventById(Guid id);
        Task<ResponseDto<List<EventDto>>> GetAllEventsAsync();
    }
}
