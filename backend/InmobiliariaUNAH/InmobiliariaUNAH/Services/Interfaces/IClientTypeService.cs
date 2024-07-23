using InmobiliariaUNAH.Dtos.ClientType;
using InmobiliariaUNAH.Dtos.common;

namespace InmobiliariaUNAH.Services.Interfaces
{
    public interface IClientTypeService
    {
        Task<ResponseDto<List<ClientTypeDto>>> GetClientsTypesListAsync();
        Task<ResponseDto<ClientTypeDto>> GetClientTypeAsync(Guid id);
        Task<ResponseDto<ClientTypeDto>> CreateClientTypeAsync(ClientTypeCreateDto dto);
        Task<ResponseDto<ClientTypeDto>> EditClientTypeAsync(ClientTypeEditDto dto, Guid id);
        Task<ResponseDto<ClientTypeDto>> DeleteClientTypeAsync(Guid id);
    }
}
