using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Events;
using InmobiliariaUNAH.Services.Interfaces;

namespace InmobiliariaUNAH.Services
{
    public class EventsService : IEventService
    {
        public Task<ResponseDto<EventDto>> CreateEvent(EventCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
