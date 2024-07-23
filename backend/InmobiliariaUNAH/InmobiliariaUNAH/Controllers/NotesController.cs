using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Notes;
using InmobiliariaUNAH.Dtos.Products;
using InmobiliariaUNAH.Services;
using InmobiliariaUNAH.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InmobiliariaUNAH.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NotesController:ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<NoteDto>>>> GetAll()
        {
            var response = await _noteService.GetNotesListAsync();

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ResponseDto<NoteDto>>> GetNoteById(Guid Id)
        {
            var response = await _noteService.GetNoteByIdAsync(Id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("event/{eventId}")]
        public async Task<ActionResult<ResponseDto<List<NoteDto>>>> GetNotesByEventId(Guid eventId)
        {
            var response = await _noteService.GetNoteByEventIdListAsync(eventId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNote(NoteCreateDto dto)
        {

            var response = await _noteService.CreateNoteAsync(dto);
            return StatusCode(Response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditNoteById(NoteEditDto dto, Guid Id)
        {
            var Response = await _noteService.EditNoteAsync(dto, Id);
            return StatusCode(Response.StatusCode, Response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var response = await _noteService.DeleteNoteAsync(Id);
            return StatusCode(Response.StatusCode, response);

        }
    }
}
