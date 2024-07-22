using AutoMapper;
using InmobiliariaUNAH.Database;
using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Notes;
using InmobiliariaUNAH.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaUNAH.Services
{
    public class NotesService : INoteService
    {
        private readonly InmobiliariaUNAHContext _context;
        private readonly IMapper _mapper;

        public NotesService(InmobiliariaUNAHContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Eventos de listar
        public async Task<ResponseDto<List<NoteDto>>> GetNotesListAsync()
        {
            var notesEntity = await _context.Notes.ToListAsync();
            var notes = _mapper.Map<List<NoteDto>>(notesEntity);
            return new ResponseDto<List<NoteDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de Categorias Obtenida Correctamente",
                Data = notes
            };
        }
        public Task<ResponseDto<NoteDto>> GetNoteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<ResponseDto<List<NoteDto>>> GetNoteByEventIdListAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        // Ebentos de editar eliminar o crear

        public Task<ResponseDto<NoteDto>> CreateNoteAsync(NoteCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<NoteDto>> DeleteNoteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<NoteDto>> EditNoteAsync(NoteEditDto dto, Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
