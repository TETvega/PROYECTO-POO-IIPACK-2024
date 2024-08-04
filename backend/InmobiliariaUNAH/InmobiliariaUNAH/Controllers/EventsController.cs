using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Events;
using InmobiliariaUNAH.Dtos.Products;
using InmobiliariaUNAH.Services;
using InmobiliariaUNAH.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InmobiliariaUNAH.Controllers
{
    [ApiController]
    [Route("api/eventos")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventsController(IEventService eventService) 
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<EventDto>>> GetAll()
        {
            var response = await _eventService.GetAllEventsAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ResponseDto<EventDto>>> GeEventById(Guid id)
        {
            var response = await _eventService.GeEventById(id);
            return StatusCode(response.StatusCode, response);
        }

      

        [HttpPost]
        public async Task<ActionResult<ResponseDto<EventDto>>> CreateEvent(EventCreateDto dto)
        {
            var response = await _eventService.CreateEvent(dto);
            return StatusCode(response.StatusCode, response);
        }
    }
}
