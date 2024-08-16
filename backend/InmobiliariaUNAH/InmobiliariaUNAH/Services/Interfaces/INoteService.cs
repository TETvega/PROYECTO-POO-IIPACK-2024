using InmobiliariaUNAH.Dtos.common;
using InmobiliariaUNAH.Dtos.Notes;
using InmobiliariaUNAH.Dtos.Products;

namespace InmobiliariaUNAH.Services.Interfaces
{
    public interface INoteService
    {
        Task<ResponseDto<List<NoteDto>>> GetNotesListAsync();
        Task<ResponseDto<List<NoteDto>>> GetNoteByEventIdListAsync(Guid id);
        Task<ResponseDto<NoteDto>> GetNoteByIdAsync(Guid id);
        Task<ResponseDto<NoteDto>> CreateNoteAsync(NoteCreateDto dto);
        Task<ResponseDto<NoteDto>> EditNoteAsync(NoteEditDto dto, Guid id);
        Task<ResponseDto<NoteDto>> DeleteNoteAsync(Guid id);
    }
}
