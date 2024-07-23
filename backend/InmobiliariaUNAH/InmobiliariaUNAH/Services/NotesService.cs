using AutoMapper;
using InmobiliariaUNAH.Database;
using InmobiliariaUNAH.Database.Entities;
using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Notes;
using InmobiliariaUNAH.Dtos.Products;
using InmobiliariaUNAH.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
        public async Task<ResponseDto<NoteDto>> GetNoteByIdAsync(Guid id)
        {
            var noteEntity = await _context.Notes.FirstOrDefaultAsync(note => note.Id == id);
            if (noteEntity == null)
            {
                return new ResponseDto<NoteDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se Encontro el Registro de la Nota"
                };
            }
            var noteDto = _mapper.Map<NoteDto>(noteEntity);

            return new ResponseDto<NoteDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro encontrado",
                Data = noteDto

            };
        }
        public async Task<ResponseDto<List<NoteDto>>> GetNoteByEventIdListAsync(Guid id)
        {
            var noteEntities = await _context.Notes.Where(note => note.EventId == id).ToListAsync();

            if (!noteEntities.Any())
            {
                return new ResponseDto<List<NoteDto>>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontraron registros de notas para el evento especificado"
                };
            }

            var noteDtos = _mapper.Map<List<NoteDto>>(noteEntities);

            return new ResponseDto<List<NoteDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registros encontrados",
                Data = noteDtos
            };
        }


        // Ebentos de editar eliminar o crear

        public async Task<ResponseDto<NoteDto>> CreateNoteAsync(NoteCreateDto dto)
        {
            var noteEntity = _mapper.Map<NoteEntity>(dto);

            // para ver que no se repita el titulo
            var existingNote = await _context.Notes.FirstOrDefaultAsync(n => n.Title.ToLower().Trim() == noteEntity.Title.ToLower().Trim());
            if (existingNote != null)
            {
                return new ResponseDto<NoteDto>
                {
                    StatusCode = 400,
                    Status = false,
                    Message = "Una nota con el mismo titulo ya existe",
                    Data = null
                };
            }
            _context.Notes.Add(noteEntity);
            await _context.SaveChangesAsync();
            var noteDto = _mapper.Map<NoteDto>(noteEntity);
            //exito al registrar
            return new ResponseDto<NoteDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro Creado de una Nota",
                Data = noteDto
            };

        }

        public async Task<ResponseDto<NoteDto>> DeleteNoteAsync(Guid id)
        {
            var noteEntity = await _context.Notes.FirstOrDefaultAsync(note => note.Id == id);
            if (noteEntity == null)
            {
                return new ResponseDto<NoteDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontro el resgistro de la nota"
                };

            }

            _context.Notes.Remove(noteEntity);
            await _context.SaveChangesAsync();
            return new ResponseDto<NoteDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "La nota Eliminado con Exito"
            };
        }

        public async Task<ResponseDto<NoteDto>> EditNoteAsync(NoteEditDto dto, Guid id)
        {
            var noteEntity = await _context.Notes.FirstOrDefaultAsync(note => note.Id == id);
            if (noteEntity == null)
            {
                return new ResponseDto<NoteDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se Encontro el Registro"
                };
            }
            _mapper.Map<NoteEditDto, NoteEntity>(dto, noteEntity);
            _context.Notes.Update(noteEntity);
            await _context.SaveChangesAsync();

            var noteDto = _mapper.Map<NoteDto>(noteEntity);
            return new ResponseDto<NoteDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Exito al editar",
                Data = noteDto,

            };
        }

    }
}
