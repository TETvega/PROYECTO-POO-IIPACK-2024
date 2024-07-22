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
            noteService = noteService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<NoteDto>>>> GetAll()
        {
            var response = await _noteService.GetNotesListAsync();

            return StatusCode(response.StatusCode, response);
        }
    }
}
